using System;
using System.Collections.Generic;
using System.Configuration;
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
            public static SqlConnection Conectar()
            {

                string conn = Globales.Parametros.CadenaConexion;
                SqlConnection cn = new SqlConnection(conn);
                return cn;

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
        public bool Inicia_Sesion(string cnx,string usrx, string pwdx,string ciax)
        {
            _CadenaConexion = cnx;
            //usare uno de prueba no dejare la conexion en globales
            try
            {
                using (SqlConnection cn = DAO.Conexion.Conectar())
                {
                    cn.Open();
                    cn.Close();
                }
            }
            catch (SqlException)
            {

                MessageBox.Show("Error de conexión", "ERROR CONEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            bool ret = true;
            return ret;
        }
    }
}
