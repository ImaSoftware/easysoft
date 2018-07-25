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
            SetHelpGen();


        }
        protected void SetHelpGen()
        {

            try
            {
                List<SqlParameter> miPar = new List<SqlParameter>();
                miPar.Add(new SqlParameter("@cLLave", codForm));
                DataTable dttConf = DLIB.Globales.Parametros.connSql.TraerTabla("SEARCH_001", miPar);
                if (dttConf == null)
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Error al configurar la ayuda automática... Verifique ");
                    return;
                }
                if (dttConf.Rows.Count != 1)
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("El conjunto de resultados vino vacío o el codigo está repetido... Verifique ");
                    return;
                }
                //Aqui ya se que la configuracion es unica
                Sentencia = (dttConf.Rows[0]["sentencia"] == null ? "" : (string)dttConf.Rows[0]["sentencia"]);

                ///Capturar titulo. Si es ALPTABLA recoger desde el nomtag. Asumo que el primer parámetro es el nomtag 
                if (codForm.ToUpper().Trim() == "ALPTABLA")
                {
                    string sql = "select nombre from alptabla where nomtag = @nomtag";
                    List<SqlParameter> pp = new List<SqlParameter>();
                    pp.Add(sqlPar[0]);
                    Titulo = DLIB.Globales.Parametros.connSql.TraerTabla("SEARCH_002", pp).Rows[0]["Nombre"].ToString().Trim();
                }
                else
                {
                    //El titulo especificado en la tabla
                    this.Titulo = (dttConf.Rows[0]["titulo"] == null ? "" : (string)dttConf.Rows[0]["titulo"]);
                 }
                Orden = (dttConf.Rows[0]["orden"] == null  ? 1 : Convert.ToInt32(dttConf.Rows[0]["orden"]));

                FocusedBackColor = Color.FromArgb((Convert.ToInt32((dttConf.Rows[0]["colbfoco"] == null ? 0: (decimal)dttConf.Rows[0]["colbfoco"]))));
                FocusedFontColor = Color.FromArgb(Convert.ToInt32((dttConf.Rows[0]["colffoco"] == null ? 0 : (decimal)dttConf.Rows[0]["colffoco"])));
                NormalBackColor = Color.FromArgb(Convert.ToInt32((dttConf.Rows[0]["colbstd"] == null ? 0 : (decimal)dttConf.Rows[0]["colffoco"])));
                NormalFontColor = Color.FromArgb(Convert.ToInt32((dttConf.Rows[0]["colfstd"] == null ? 0 : (decimal)dttConf.Rows[0]["colffoco"])));
                Object[] x = (dttConf.Rows[0]["hgSize"]).ToString().Split(',');
                if (x.Length != 2)
                {
                    MessageBox.Show("Parámetro HGSIZE inválido");
                    connErr = true; this.DialogResult = DialogResult.Cancel; return;
                }
                this.mySize = new Size(Convert.ToInt32(x[0]), Convert.ToInt32(x[1]));
                x = new object[0]; x = (dttConf.Rows[0]["titulo_col"] == null ? "" : (string)dttConf.Rows[0]["titulo_col"]).ToString().Trim().Split('-');
                if (String.IsNullOrEmpty(x[0].ToString()))
                {
                    string aa = "CODIGO-NOMBRE";
                    x = aa.Split('-');
                }
                Array.Resize<string>(ref tituloCol, x.Length);
                Array.Copy(x, tituloCol, x.Length);
                if (String.IsNullOrEmpty((dttConf.Rows[0]["HideFields"] == null ? "" : (string)dttConf.Rows[0]["HideFields"]).ToString().Trim()))
                {
                    HideFields = new string[0];

                }
                else
                {
                    x = new object[0]; x = (dttConf.Rows[0]["HideFields"] == null ? "" : (string)dttConf.Rows[0]["HideFields"]).ToString().Trim().Split(',');
                    Array.Resize<string>(ref HideFields, x.Length);
                    Array.Copy(x, HideFields, x.Length);
                }


                x = new object[0]; x = (dttConf.Rows[0]["s_col_din"] == null ? "" : (string)dttConf.Rows[0]["s_col_din"]).ToString().Trim().Split(';');
                Array.Resize<string>(ref sent_col_din, x.Length);
                Array.Copy(x, sent_col_din, x.Length);
                x = new object[0]; x = (dttConf.Rows[0]["autosize_col"] == null ? "" : (string)dttConf.Rows[0]["autosize_col"]).ToString().Trim().Split(',');
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
                            command.Parameters.Add(new SqlParameter(xp.ParameterName, xp.Value));
                        }
                    }
                   
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    tbl_Prin = new DataTable();
                    da.Fill(tbl_Prin);
                    cn.Close();
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

            using (SqlConnection cn = DAO.Conexion.Conectar())
            {
                SqlCommand command = new SqlCommand(Sentencia, cn);
                if (sqlPar != null) {
                    foreach (SqlParameter xp in sqlPar)
                    {
                        command.Parameters.Add(new SqlParameter(xp.ParameterName, xp.Value));
                    }
                }
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                tbl_Prin = new DataTable();
                da.Fill(tbl_Prin);
                cn.Close();
                if (tbl_Prin == null)
                {
                    MessageBox.Show("Error al cargar la consulta especificada en Sentencia");
                    connErr = true; this.DialogResult = DialogResult.Cancel; return;
                }
            }
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
                if (GV_Consulta.Rows.Count > 0)
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
            this.DialogResult = DialogResult.OK;
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
            if (opt == 0)
            {
                //Formula
                try
                {
                    tbl_Prin.DefaultView.RowFilter = ctlSearch.Text;
                }
                catch (Exception ex)
                {
                    errP.SetError(ctlSearch, ex.Message);
                }

            }
            else
            {
                //Normal
                //Que columna has seleccionado 
                try
                {
                    if (String.IsNullOrEmpty(ctlSearch.Text))
                    {
                        tbl_Prin.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(colSearch))
                        {
                            string filterStr = "";
                            foreach (DataColumn dc in tbl_Prin.Columns)
                            {
                                if (dc.DataType == typeof(string))
                                {
                                    filterStr = filterStr + (dc.Ordinal == 0 ? "" : " OR ") + dc.ColumnName + " like '%" + ctlSearch.Text.Trim() + "%'";
                                }
                                else
                                {
                                    int result;
                                    if (int.TryParse(ctlSearch.Text.Trim(), out result))
                                    {
                                        filterStr = filterStr + (dc.Ordinal == 0 || String.IsNullOrEmpty(filterStr) ? "" : " OR ") + dc.ColumnName + " = " + ctlSearch.Text.Trim();
                                    }
                                }
                            }
                            tbl_Prin.DefaultView.RowFilter = filterStr;
                        }
                        else
                        {
                            if (tbl_Prin.Columns[colSearch].DataType == typeof(string))
                            {
                                tbl_Prin.DefaultView.RowFilter = colSearch + " like '%" + ctlSearch.Text.Trim() + "%'";
                            }
                            else
                            {
                                tbl_Prin.DefaultView.RowFilter = colSearch + " = " + ctlSearch.Text.Trim();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    errP.SetError(ctlSearch, ex.Message);
                }
            }
        }

        private void ctlSearch_Leave(object sender, EventArgs e)
        {
            if (L_Modo) { FiltraDtt(0); } else { FiltraDtt(1); }
        }

        private void GV_Consulta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            colSearch = tbl_Prin.Columns[e.ColumnIndex].ColumnName;
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

        private void easySearch_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        private void easySearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;

        }
    }
}
