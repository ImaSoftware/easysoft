using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLIB
{
    public class FrmInfo {
        private bool _Err = false;
        public bool Err
        {
            get { return _Err; }
            // set { _NombreMostrar = value; }
        }
        private string _NombreMostrar = "";
        public string NombreMostrar
        {
            get { return _NombreMostrar; }
            // set { _NombreMostrar = value; }
        }
        private string _CtlNom = "";
        public string CtlNom
        {
            get { return _CtlNom; }
            // set { _CtlNom = value; }
        }
        private string _CtlOpt = "";
        public string CtlOpt
        {
            get { return _CtlOpt; }
            // set { _CtlOpt = value; }
        }
        private int _WinState = (int)FormWindowState.Normal;
        public int WinState
        {
            get { return _WinState; }
            // set { _WinState = value; }
        }
        public void LLenarInfo(DataTable tbinfo) {
            if (tbinfo == null) {
                _Err = true;
                return;
            }
            if (tbinfo.Rows.Count != 1)
            {
                _Err = true;
                return;
            }
            this._NombreMostrar = tbinfo.Rows[0]["NombreMostrar"].ToString();
            this._CtlNom = tbinfo.Rows[0]["CtlNom"].ToString();
            this._CtlOpt = tbinfo.Rows[0]["CtlOpt"].ToString();
            this._WinState = (int)tbinfo.Rows[0]["winState"];
        }

        
    }
    public class DAO
    {
        private bool _HayError = false;
        public bool HayError
        {
            get { return _HayError; }
            // set { _HayError = value; }
        }
        public DAO()
        {


        }
        public class Conexion
        {
            public static SqlConnection Conectar(bool root =false)
            {

                string conn = root ? Globales.Parametros.CadenaConexionRoot:Globales.Parametros.CadenaConexion;
                SqlConnection cn = new SqlConnection(conn);
                return cn;

            }
            public DataTable TraerTabla(string idTabla, List<SqlParameter> xpar =null, bool esRoot=false)
            {
                DataTable ret=null;
                try
                {
                    using (SqlConnection cn = DAO.Conexion.Conectar(String.IsNullOrEmpty(Globales.Parametros.CadenaConexion) || esRoot))
                    {
                        //traer la consulta especificada
                        string sql = @"select consulta from davmerTablas where codtabla = @codTabla";
                        SqlCommand command = new SqlCommand(sql, cn);
                        command.Parameters.Add("@codTabla", SqlDbType.VarChar);
                        command.Parameters["@codTabla"].Value = idTabla;
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        if (dt.Rows.Count != 1)
                        {
                            MessageBox.Show("No existe la tabla especificada o está duplicada: "+ Environment.NewLine + idTabla.Trim(), "ERROR DAVMERTABLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return null;
                        }
                        string query = dt.Rows[0][0].ToString();
                        command = new SqlCommand(query, cn);
                        //Agrego parametros de la consulta
                        if (xpar != null)
                        {
                            foreach (SqlParameter p in xpar)
                            {
                                command.Parameters.Add(new SqlParameter( p.ParameterName,p.Value));
                            }
                        }
                        cn.Open();
                        da = new SqlDataAdapter(command);
                        ret = new DataTable();
                        da.Fill(ret);
                        cn.Close();
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Error de conexión:" + Environment.NewLine + ex.Message, "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                return ret;
            }
        }
 
    }
    public static class DFUNC
    {
        public static string GetSafeFilename(string filename)
        {

            return string.Join("", filename.Split(Path.GetInvalidFileNameChars()));

        }
    }
    public static class Globales {
        
        public static GlobC Parametros = new GlobC();
        
    }
    public class GlobC
    {
        public DAO.Conexion connSql= new DAO.Conexion();
        private string _UsrNom = "";
        public string UsrNom
        {
            get { return _UsrNom; }
            // set { _UsrNom = value; }
        }
        private string _CadenaConexionRoot = "";
        public string CadenaConexionRoot
        {
            get { return _CadenaConexionRoot; }
             set { _CadenaConexionRoot = value; }
        }
        private string _CadenaConexion = "";
        public string CadenaConexion
        {
            get { return _CadenaConexion; }
           // set { _CadenaConexion = value; }
        }
        private string _CodUser = "";
        public string CodUser
        {
            get { return _CodUser; }
            //set{_CodUser = value;}
        }
        private string _CodCia = "";
        public string CodCia
        {
            get { return _CodCia; }
            //set{_CadenaConexion = value;}
        }

        /// <summary>
        /// Inicia sesion con los parametros dados y deja la conexion resultante grabada en Globales
        /// </summary>
        /// <param name="cnx"> Cadena de conexion del root</param>
        /// <param name="usrx">nombre de usuario para identificarse</param>
        /// <param name="pwdx">clave</param>
        /// <param name="ciax">codigo de empresa</param>
        /// <returns></returns>
        public bool Inicia_Sesion(string cnRoot,string usrx, string pwdx,int ciax)
        {
            _CadenaConexionRoot = cnRoot; 
            try
            {
                using (SqlConnection cn = DAO.Conexion.Conectar(true))
                {
                    //traer la cadena de conexion de la cia indicada si es exitosa 
                    string sql = @"SELECT (select Nombre from usuarios where CAST(usernom as varbinary(100)) = CAST(@nomuser as varbinary) 
                                AND CAST(userpwd as varbinary(100)) = CAST(@pwd as varbinary(100)) ), a.connstring  FROM empresas A inner join
                                (select codcia from Permisos where tipo='E' and  usercod= isnull(
                                (select codigo from usuarios where CAST(usernom as varbinary(100)) = CAST(@nomuser as varbinary) 
                                AND CAST(userpwd as varbinary(100)) = CAST(@pwd as varbinary(100)) ),0) ) B on a.codcia=B.codcia 
                                where A.codcia = @codcia";
                    SqlCommand command = new SqlCommand(sql, cn);
                    command.Parameters.Add("@codcia", SqlDbType.Int );
                    command.Parameters["@codcia"].Value = ciax;
                    command.Parameters.Add("@nomuser", SqlDbType.VarChar);
                    command.Parameters["@nomuser"].Value = usrx;
                    command.Parameters.Add("@pwd", SqlDbType.VarChar);
                    command.Parameters["@pwd"].Value = pwdx;
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cn.Close();
                    if (dt.Rows.Count != 1)
                    {
                        return false;
                    }
                    _CadenaConexion = dt.Rows[0][1].ToString();
                    _UsrNom = dt.Rows[0][0].ToString();
                    using (SqlConnection cn2 = DAO.Conexion.Conectar())
                    {
                        cn2.Open();
                        cn2.Close();
                    }
                   
                    //si llego hasta este punto es porque si existe y si vale la segunda cadena de conexion
                                      

                }
            }
            catch (SqlException ex)
            {
                _CadenaConexionRoot = "";
                _CadenaConexion = "";
                _UsrNom = "";
                throw ex;
            }
            
            bool ret = true;
            return ret;
        }
    }
}
