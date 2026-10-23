using DLIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class easySearch : baseClass.easyForm 
    {
        string codForm;
        string valRet;
        List<SqlParameter> sqlPar = new List<SqlParameter>();
        public object xdev = null;
        public DialogResult myRes;


        DataTable tbl_Prin = null;
  
        string colSearch = "";
  
        bool connErr = false;
        public object Resultado;
  
        //Propiedades
        public Size mySize;
        string Sentencia;
        string[] tituloCol;
        string[] HideFields;
        string[] sent_col_din = new string[0];
        int Orden;
        DataGridViewAutoSizeColumnMode[] auto_col;
        Color FocusedBackColor;
        Color NormalBackColor;
        Color FocusedFontColor;
        Color NormalFontColor;
        bool L_Modo = false;


        public easySearch(string xCode, string xRet, List<SqlParameter>  _sqlPar = null)
        {
            InitializeComponent();
            codForm = xCode;
            valRet = xRet;
            sqlPar = _sqlPar;

            GV_Consulta.KeyDown += ctlSearch_KeyDown;
            ctlSearch.KeyDown += ctlSearch_KeyDown;



        }
        protected async Task SetHelpGen()
        {

            try
            {
                List<SqlParameter> miPar = new List<SqlParameter>();
                miPar.Add(new SqlParameter("@cLLave", codForm));
                DataTable dttConf = await Task.Run(() => DLIB.Globales.Parametros.connSql.TraerTabla("SEARCH_001", miPar));
                if (IsDisposed) return;
                if (dttConf == null)
                {
                    connErr = true; this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Error al configurar la ayuda automática... Verifique ");
                    return;
                }
                if (dttConf.Rows.Count != 1)
                {
                    connErr = true; this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("El conjunto de resultados vino vacío o el codigo está repetido... Verifique ");
                    return;
                }
                //Aqui ya se que la configuracion es unica
                Sentencia = (dttConf.Rows[0]["sentencia"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["sentencia"]);

                ///Capturar titulo. Si es ALPTABLA recoger desde el nomtag. Asumo que el primer parámetro es el nomtag 
                if (codForm.ToUpper().Trim() == "ALPTABLA")
                {

                    List<SqlParameter> pp = new List<SqlParameter>();
                    if (sqlPar == null || sqlPar.Count == 0) throw new InvalidOperationException("Falta el parámetro de búsqueda.");
                    pp.Add(sqlPar[0]);
                    var title = await Task.Run(() => DLIB.Globales.Parametros.connSql.TraerTabla("SEARCH_002", pp));
                    if (IsDisposed) return;
                    if (title == null || title.Rows.Count != 1) throw new InvalidOperationException("No se encontró la configuración de búsqueda.");
                    Titulo = Convert.ToString(title.Rows[0]["Nombre"]).Trim();
                }
                else
                {
                    //El titulo especificado en la tabla
                    this.Titulo = (dttConf.Rows[0]["titulo"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["titulo"]);
                 }
                Orden = (dttConf.Rows[0]["orden"] == DBNull.Value  ? 1 : Convert.ToInt32(dttConf.Rows[0]["orden"]));

                FocusedBackColor = Color.FromArgb((Convert.ToInt32((dttConf.Rows[0]["colbfoco"] == DBNull.Value ? 0: (decimal)dttConf.Rows[0]["colbfoco"]))));
                FocusedFontColor = Color.FromArgb(Convert.ToInt32((dttConf.Rows[0]["colffoco"] == DBNull.Value ? 0 : (decimal)dttConf.Rows[0]["colffoco"])));
                NormalBackColor = Color.FromArgb(Convert.ToInt32((dttConf.Rows[0]["colbstd"] == DBNull.Value ? 0 : (decimal)dttConf.Rows[0]["colbstd"])));
                NormalFontColor = Color.FromArgb(Convert.ToInt32((dttConf.Rows[0]["colfstd"] == DBNull.Value ? 0 : (decimal)dttConf.Rows[0]["colfstd"])));
                Object[] x = (dttConf.Rows[0]["hgSize"]).ToString().Split(',');
                if (x.Length != 2)
                {
                    MessageBox.Show("Parámetro HGSIZE inválido");
                    connErr = true; this.DialogResult = DialogResult.Cancel; return;
                }
                this.mySize = new Size(Convert.ToInt32(x[0]), Convert.ToInt32(x[1]));
                x = new object[0]; x = (dttConf.Rows[0]["titulo_col"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["titulo_col"]).ToString().Trim().Split('-');
                if (String.IsNullOrEmpty(x[0].ToString()))
                {
                    string aa = "CODIGO-NOMBRE";
                    x = aa.Split('-');
                }
                Array.Resize<string>(ref tituloCol, x.Length);
                Array.Copy(x, tituloCol, x.Length);
                if (String.IsNullOrEmpty((dttConf.Rows[0]["HideFields"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["HideFields"]).ToString().Trim()))
                {
                    HideFields = new string[0];

                }
                else
                {
                    x = new object[0]; x = (dttConf.Rows[0]["HideFields"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["HideFields"]).ToString().Trim().Split(',');
                    Array.Resize<string>(ref HideFields, x.Length);
                    Array.Copy(x, HideFields, x.Length);
                }


                x = new object[0]; x = (dttConf.Rows[0]["s_col_din"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["s_col_din"]).ToString().Trim().Split(';');
                Array.Resize<string>(ref sent_col_din, x.Length);
                Array.Copy(x, sent_col_din, x.Length);
                x = new object[0]; x = (dttConf.Rows[0]["autosize_col"] == DBNull.Value ? "" : (string)dttConf.Rows[0]["autosize_col"]).ToString().Trim().Split(',');
                Array.Resize<DataGridViewAutoSizeColumnMode>(ref auto_col, x.Length);
                for (int i = 0; i < auto_col.Length; i++)
                {
                    auto_col[i] = (DataGridViewAutoSizeColumnMode)Convert.ToInt32(x[i]);
                }
                //tengo cargado todo lo que necesito para configurar el form (YEAH)
                GV_Consulta.DefaultCellStyle.SelectionBackColor = FocusedBackColor;
                GV_Consulta.DefaultCellStyle.SelectionForeColor = FocusedFontColor;
                // GV_Consulta.DefaultCellStyle.BackColor = NormalBackColor;
                GV_Consulta.DefaultCellStyle.ForeColor = NormalFontColor;
                //Validar que tenga sentido lo que he cargado
                //cargo la data para poder saber el numero de columnas que trae la sentencia 

                using (SqlConnection cn = DAO.Conexion.Conectar())
                {
                    // El nombre del repo me indica que debo buscar
                    SqlCommand command = new SqlCommand(Sentencia, cn);
                    if (sqlPar != null) {
                        foreach (SqlParameter xp in sqlPar)
                        {
                            command.Parameters.Add((SqlParameter)((ICloneable)xp).Clone());
                        }
                    }
                   
                    tbl_Prin = await Task.Run(() => {
                        using (var adapter = new SqlDataAdapter(command)) {
                            var result = new DataTable();
                            cn.Open(); adapter.Fill(result); cn.Close();
                            return result;
                        }
                    });
                    if (IsDisposed) return;
                    if (tbl_Prin == null)
                    {
                        MessageBox.Show("Error al traer el conjunto de resultados");
                        connErr = true; this.DialogResult = DialogResult.Cancel; return;
                    }
                    //1.- Los campos visibles son por lo menos dos 
                    int totColData = tbl_Prin.Columns.Count;
                    int visibleFields = totColData - HideFields.Length;
                    if (visibleFields < 2)
                    {
                        MessageBox.Show("Como mínimo se espera dos campos a visualizar");
                        connErr = true;this.DialogResult = DialogResult.Cancel; return;
                    }
                    //Tengo cargado todo lo que necesito para configurar el form 
                    //las configuraciones de columna solo se aplican a los campos visibles 
                    //por lo tanto deben coincidir en numero 
                    if (tituloCol.Length != visibleFields)
                    {
                        MessageBox.Show("Error en configuración: titulo_col");
                        connErr = true; this.DialogResult = DialogResult.Cancel; return;
                    }
                    if (auto_col.Length != visibleFields)
                    {
                        MessageBox.Show("Error en configuración: autosize_col");
                        connErr = true; this.DialogResult = DialogResult.Cancel; return;
                    }
                }
            }
            catch (Exception ex)
            {
                connErr = true;
                MessageBox.Show("Error:" + ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel; return;
            }
        }
        private void Consultar()
        {

            if (tbl_Prin == null) return;
            // colSearch = tbl_Prin.Columns[0].ColumnName;
            GV_Consulta.AutoGenerateColumns = true;
            GV_Consulta.DataSource = tbl_Prin;
            GV_Consulta.Refresh();
            //Aplicar configuracion de columnas
            //Ocultar columnas 
            for (int j = 0; j < HideFields.Length; j++)
            {
                GV_Consulta.Columns[HideFields[j]].Visible = false;
            }
            int i = 0;
            int visibleFields = auto_col.Length;
            foreach (DataGridViewColumn dgvC in GV_Consulta.Columns)
            {
                if (dgvC.Visible && i < visibleFields)
                {
                    dgvC.AutoSizeMode = auto_col[i];
                    dgvC.HeaderText = tituloCol[i];
                    i++;
                }
            }
            GV_Consulta.Refresh();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (L_Modo) { FiltraDtt(0); } else { FiltraDtt(1); }
        }

        private void ctlSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Retornar(1); }
            if (e.KeyCode == Keys.Escape) { Retornar(0); }
        }
        private void Retornar(int opt)
        {
            this.Resultado = null;

            DataGridViewCell activa = GV_Consulta.CurrentCell;
            if (opt == 1)
            {
                if (GV_Consulta.Rows.Count > 0 && activa != null)
                {
                    if (valRet.ToUpper().Trim() != "TODOS")
                    {
                        this.Resultado = ((DataRowView)GV_Consulta.Rows[activa.RowIndex].DataBoundItem)[this.valRet];
                    }
                    else
                    {
                        this.Resultado = GV_Consulta.Rows[activa.RowIndex].DataBoundItem;
                    }
                }
            }
            else { this.Resultado = null; }
            //aqui hacer raise event
            this.DialogResult = opt == 1 ? DialogResult.OK : DialogResult.Cancel;
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            if (!L_Modo)
            {
                btnMode.Image = this.misImagenes.Images[1];
            }
            else
            {
                btnMode.Image = null;
            }
            L_Modo = !L_Modo;
        }

        private void ctlSearch_TextChanged(object sender, EventArgs e)
        {
            if (L_Modo) { FiltraDtt(0); } else { FiltraDtt(1); }
        }
        private void FiltraDtt(int opt)
        {
            errP.SetError(ctlSearch, "");
            if (tbl_Prin == null) return;
            try
            {
                tbl_Prin.DefaultView.RowFilter = opt == 0 ? ctlSearch.Text : SearchFilter.Build(tbl_Prin, ctlSearch.Text, colSearch);
            }
            catch (EvaluateException ex) { errP.SetError(ctlSearch, ex.Message); }
            catch (SyntaxErrorException ex) { errP.SetError(ctlSearch, ex.Message); }
        }
        private void ctlSearch_Leave(object sender, EventArgs e)
        {
            if (L_Modo) { FiltraDtt(0); } else { FiltraDtt(1); }
        }

        private void GV_Consulta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || tbl_Prin == null) return;
            colSearch = GV_Consulta.Columns[e.ColumnIndex].DataPropertyName;
            if (L_Modo)
            {
                ctlSearch.Text = ctlSearch.Text + " " + colSearch;
            }
        }

        private void GV_Consulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            if (GV_Consulta.Rows.Count > 0) { Retornar(1); }
        }

        private async void easySearch_Load(object sender, EventArgs e)
        {
            Enabled = false;
            try { await SetHelpGen(); if (!connErr && !IsDisposed) Consultar(); }
            catch (Exception ex) { connErr = true; if (!IsDisposed) MessageBox.Show("No se pudo cargar la búsqueda: " + ex.Message); }
            finally { if (!IsDisposed) Enabled = true; }
            if (IsDisposed) return;
            if (connErr) { DialogResult = DialogResult.Cancel; Close(); return; }
        }

        private void easySearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;

        }
    }
}
