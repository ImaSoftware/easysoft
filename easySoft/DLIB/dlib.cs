using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLIB
{
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
            public DataTable TraerTabla(string idTabla)
            {
                DataTable ret=null;
                try
                {
                    using (SqlConnection cn = DAO.Conexion.Conectar(String.IsNullOrEmpty(Globales.Parametros.CadenaConexion)))
                    {
                        //traer la consulta especificada
                        string sql = @"select consulta from davmerTablas where codtabla = @codTabla";
                        SqlCommand command = new SqlCommand(sql, cn);
                        command.Parameters.Add("@codTabla", SqlDbType.Int);
                        command.Parameters["@codTabla"].Value = idTabla;
                        cn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        if (dt.Rows.Count != 1)
                        {
                            MessageBox.Show("No existe la tabla especificada o está duplicada", "ERROR DAVMERTABLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return null;
                        }
                        string query = dt.Rows[0][0].ToString();
                        command = new SqlCommand(sql, cn);
                        cn.Open();
                        da = new SqlDataAdapter(command);
                        ret = new DataTable();
                        da.Fill(ret);
                        cn.Close();
                    }
                }
                catch (SqlException)
                {

                    MessageBox.Show("Error de conexión", "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                return ret;
            }
        }
 
    }
    public static class DFUNC
    {

    }
    public static class Globales {
        
        public static GlobC Parametros = new GlobC();
        
    }
    public class GlobC
    {
        public DAO.Conexion connSql;
        private string _CadenaConexionRoot = "";
        public string CadenaConexionRoot
        {
            get { return _CadenaConexionRoot; }
            // set { _CadenaConexion = value; }
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
                    string sql = @"SELECT connstring  FROM empresas A inner join
                                    (select codcia from Permisos where tipo='E' and  usercod= isnull(
                                    (select codigo from usuarios where usernom =@nomuser and userpwd = @pwd),0) ) B on a.codcia=B.codcia 
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
                        MessageBox.Show("No existe la compañía especificada o está duplicada", "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    _CadenaConexion = dt.Rows[0][0].ToString();
                    using (SqlConnection cn2 = DAO.Conexion.Conectar())
                    {
                        cn2.Open();
                        
                        cn2.Close();
                    }
                   
                    //si llego hasta este punto es porque si existe y si vale la segunda cadena de conexion
                }
            }
            catch (SqlException)
            {
                _CadenaConexionRoot = "";
                _CadenaConexion = "";
                MessageBox.Show("Error de conexión", "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            bool ret = true;
            return ret;
        }
    }
}
