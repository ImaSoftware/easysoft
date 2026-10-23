using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Interfaz
{
    public partial class FrmGenBan : baseClass.easyForm
    {
        private bool loading = true;
        private bool exporting;
        private int loadVersion;
        public FrmGenBan() { InitializeComponent(); }
        public FrmGenBan(string xtitulo, string args) : this() { Titulo = xtitulo; }

        private async void btnGenera_Click(object sender, EventArgs e) { try { await GenerarArchivo(); } catch (Exception ex) { if (!IsDisposed) MessageBox.Show(ex.Message); } }
        private async Task GenerarArchivo()
        {
            if (exporting || loading || dgvRoles.SelectedRows.Count == 0) return;
            var bank = cmbBanco.SelectedItem as DataRowView;
            if (bank == null) { MessageBox.Show("Seleccione un banco."); return; }
            if (dgvRoles.SelectedRows.Count > 1 && MessageBox.Show("¿Exportar los roles seleccionados?", "Confirmación", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var roles = dgvRoles.SelectedRows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow).Select(row => new {
                    Name = Convert.ToString(row.Cells["cTipo"].Value),
                    From = Convert.ToDateTime(row.Cells["cFecDesde"].Value),
                    To = Convert.ToDateTime(row.Cells["cFecHasta"].Value)
                }).ToList();
            string query = Convert.ToString(bank.Row["consulta"]).Trim();
            string format = Convert.ToString(bank.Row["tipgen"]).Trim();
            string bankCode = Convert.ToString(cmbBanco.SelectedValue).Trim();
            if (format != "T" && format.Length != 0) { MessageBox.Show("Formato de banco no reconocido."); return; }
            using (var dialog = new SaveFileDialog { Filter = "Texto Plano|*.txt" })
            {
                if (dialog.ShowDialog() != DialogResult.OK) return;
                exporting = true;
                btnGenera.Enabled = false;
                string directory = Path.GetDirectoryName(dialog.FileName);
                int success = 0;
                try
                {
                    for (int i = 0; i < roles.Count; i++)
                    {
                        var role = roles[i];
                        var parameters = new List<SqlParameter> {
                            new SqlParameter("@desde", SqlDbType.DateTime) { Value = role.From },
                            new SqlParameter("@hasta", SqlDbType.DateTime) { Value = role.To },
                            new SqlParameter("@bcodesde", bankCode)
                        };
                        DataTable data = await Task.Run(() => DLIB.Globales.Parametros.connSql.TraerTabla(query, parameters));
                        if (IsDisposed) return;
                        if (data == null || data.Rows.Count == 0) continue;
                        string name = DLIB.DFUNC.GetSafeFilename(Path.GetFileNameWithoutExtension(dialog.FileName) + "_" + role.Name + "_" + role.From.ToString("yyyyMMdd") + "-" + role.To.ToString("yyyyMMdd") + "-" + i);
                        var files = new Dictionary<string, string[]>();
                        if (format == "T")
                            files.Add(Path.Combine(directory, name + ".txt"), data.Rows.Cast<DataRow>().Select(row => string.Join("\t", row.ItemArray.Select(Convert.ToString))).ToArray());
                        else
                        {
                            if (!data.Columns.Contains("TIPO") || !data.Columns.Contains("RES")) throw new InvalidOperationException("La consulta bancaria debe devolver TIPO y RES.");
                            foreach (var group in data.Rows.Cast<DataRow>().GroupBy(row => Convert.ToString(row["TIPO"]) == "EX"))
                                files.Add(Path.Combine(directory, name + (group.Key ? "EXTERNOS" : "") + ".txt"), group.Select(row => Convert.ToString(row["RES"])).ToArray());
                        }
                        if (files.Keys.Any(File.Exists) && MessageBox.Show("Ya existen archivos para " + role.Name + ". ¿Reemplazarlos?", "Confirmación", MessageBoxButtons.YesNo) != DialogResult.Yes) continue;
                        await Task.Run(() => {
                            foreach (var file in files)
                            {
                                string temporary = file.Key + "." + Guid.NewGuid().ToString("N") + ".tmp";
                                try
                                {
                                    File.WriteAllLines(temporary, file.Value, new System.Text.UTF8Encoding(false));
                                    if (File.Exists(file.Key)) File.Replace(temporary, file.Key, null);
                                    else File.Move(temporary, file.Key);
                                }
                                finally { if (File.Exists(temporary)) File.Delete(temporary); }
                            }
                        });
                        success++;
                    }
                    if (!IsDisposed) MessageBox.Show("Roles exportados: " + success + " de " + roles.Count + ".");
                }
                catch (Exception ex) { if (!IsDisposed) MessageBox.Show("No se completó la exportación: " + ex.Message); }
                finally { exporting = false; if (!IsDisposed) btnGenera.Enabled = true; }
            }
        }

        private async Task CargaGrid()
        {
            int version = ++loadVersion;
            DateTime from = fechaini.Value.Date, to = fechahasta.Value.Date;
            if (from > to) { dgvRoles.DataSource = null; return; }
            var parameters = new List<SqlParameter> { new SqlParameter("@fecini", from), new SqlParameter("@fecfin", to) };
            var roles = await Task.Run(() => DLIB.Globales.Parametros.connSql.TraerTabla("FRMGENBAN_001", parameters));
            if (!IsDisposed && version == loadVersion) dgvRoles.DataSource = roles;
        }

        private async void FrmGenBan_Load(object sender, EventArgs e)
        {
            loading = true;
            btnGenera.Enabled = false;
            try
            {
                DateTime first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                fechaini.Value = first;
                fechahasta.Value = first.AddMonths(1).AddDays(-1);
                var banks = await Task.Run(() => DLIB.Globales.Parametros.connSql.TraerTabla("FRMGENBAN_002"));
                if (IsDisposed) return;
                cmbBanco.ValueMember = "codigo";
                cmbBanco.DisplayMember = "Nombre";
                cmbBanco.DataSource = banks;
                await CargaGrid();
            }
            catch (Exception ex) { if (!IsDisposed) MessageBox.Show("No se pudieron cargar los datos: " + ex.Message); }
            finally { loading = false; if (!IsDisposed) btnGenera.Enabled = true; }
        }
        private async void fechahasta_ValueChanged(object sender, EventArgs e)
        {
            if (loading || exporting) return;
            try { await CargaGrid(); }
            catch (Exception ex) { if (!IsDisposed) MessageBox.Show(ex.Message); }
        }
        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnGenera_Click(sender, EventArgs.Empty);
        }
    }
}