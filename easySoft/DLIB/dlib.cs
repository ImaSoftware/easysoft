﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DLIB
{
    public class MenuInfo {
        private bool _esEasy = false;
        public bool esEasy
        {
            get { return _esEasy; }
            // set { _NombreMostrar = value; }
        }
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
        private int _xtip = 0;
        public int xtip
        {
            get { return _xtip; }
            // set { _CtlOpt = value; }
        }
        private int _xcod = 0;
        public int codigo
        {
            get { return _xcod; }
            // set { _CtlOpt = value; }
        }
        private long _Nivel = 0;
        public long Nivel
        {
            get { return _Nivel; }
            // set { _CtlOpt = value; }
        }
        private string _image_Key = "";
        public string image_Key
        {
            get { return _image_Key; }
            // set { _CtlOpt = value; }
        }
        private string _codAcceso = "";
        public string codAcceso
        {
            get { return _codAcceso; }
            // set { _CtlOpt = value; }
        }
        private string _Desc = "";
        public string Desc
        {
            get { return _Desc; }
            // set { _CtlOpt = value; }
        }
        private bool _xinform = false;
        public bool Inform
        {
            get { return _xinform; }
            // set { _CtlOpt = value; }
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
            this._xcod = (int)tbinfo.Rows[0]["codigo"];
            this._NombreMostrar = tbinfo.Rows[0]["NombreMostrar"].ToString();
            this._NombreMostrar = tbinfo.Rows[0]["NombreMostrar"].ToString();
            this._CtlNom = tbinfo.Rows[0]["CtlNom"].ToString();
            this._CtlOpt = tbinfo.Rows[0]["CtlOpt"].ToString();
            this._WinState =  (int)(tbinfo.Rows[0]["winState"]==DBNull.Value?0: (int)tbinfo.Rows[0]["winState"]);
            this._xtip= (tbinfo.Rows[0]["Tipo"] == DBNull.Value ? 0 : (int)tbinfo.Rows[0]["Tipo"]);
            this._image_Key = (string)tbinfo.Rows[0]["ImageKey"].ToString();
            this._xinform = (tbinfo.Rows[0]["inForm"] == DBNull.Value ? false : (bool)tbinfo.Rows[0]["inForm"]);
            this._esEasy  = (tbinfo.Rows[0]["esEasy"] == DBNull.Value ? false : (bool)tbinfo.Rows[0]["esEasy"]);
            this._Desc = (string)tbinfo.Rows[0]["Descripcion"].ToString();
            this._codAcceso = (string)tbinfo.Rows[0]["codigoAcceso"].ToString();
            this._Nivel = _codAcceso.LongCount(letra => letra.ToString() == ".");
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
        public static string[] UsrWinReg(bool grabar = false)
        {
            if (grabar)
            {
                Interaction.SaveSetting("easysoft", "Configuracion", "UsrId", Globales.Parametros.UsrId );
                Interaction.SaveSetting("easysoft", "Configuracion", "CodCia", Globales.Parametros.CodCia.ToString());
                return null;
            }
            else
            {
                return new string[]{ Interaction.GetSetting("easysoft", "Configuracion", "UsrId"),
                Interaction.GetSetting("easysoft", "Configuracion", "CodCia")};
            }
        }
        public static string GetSafeFilename(string filename)
        {

            return string.Join("", filename.Split(Path.GetInvalidFileNameChars()));

        }
    }
    public class Parametro
    {
        public enum tipo { SoloSQL, SoloRepo, Ambos}
        public Parametro(string argN, object argVal, tipo xtipo = tipo.Ambos, int fsize = 0)
        {
            Nombre = argN;
            value = argVal;
            size = fsize;
            tip = xtipo;
        }
        public string Nombre;
        public object value;
        public int size;
        public tipo tip;
    }


    public class RepoMan
    {
        // ***********************EMULACION DE REPOMAN ***************************
        // REPORTE DINAMICO A TRAVES DE SENTENCIA ALMACENADA EN BASE DE DATOS 
        // Clase pensada para usarse como extractor de info de repo
        // ***********************************************************************
        private string clave;
        private string _Comentario = "";
        public string Comentario
        {
            get { return _Comentario; }
            // set { _UsrNom = value; }
        }
        private bool _EnableExternalImages = false;
        public bool EnableExternalImages
        {
            get { return _EnableExternalImages; }
            //  set { _EnableExternalImages = value; }
        }
        private string query;
        private List<SqlParameter> xpar = null;
        public DataSet db = new DataSet();
        public RepoMan(string _nR, List<SqlParameter> _xpar = null)
        {
            clave = _nR;
            xpar = _xpar;
        }
        public void load()
        {
            using (SqlConnection cn = DAO.Conexion.Conectar())
            {
                // El nombre del repo me indica que debo buscar
                string sql = @"Select Sentencia, EnableExternalImages, comentario from repoman where namereport = @clave ";
                SqlCommand command = new SqlCommand(sql, cn);
                command.Parameters.Add("@clave", SqlDbType.VarChar);
                command.Parameters["@clave"].Value = clave;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                cn.Close();
                if (dtt.Rows.Count != 1)
                {
                    Interaction.MsgBox("mas de una fila para definicion de reporte");
                    db = null;
                    return;
                }
                this._Comentario = (dtt.Rows[0]["COMENTARIO"] == DBNull.Value ? "" : (string)dtt.Rows[0]["COMENTARIO"]);
                this._EnableExternalImages = (dtt.Rows[0]["EnableExternalImages"] == DBNull.Value ? false : (bool)dtt.Rows[0]["EnableExternalImages"]);
                string  query = (dtt.Rows[0]["Sentencia"] == DBNull.Value ? "" : (string)dtt.Rows[0]["Sentencia"]); 
                command = new SqlCommand(query, cn);
                command.CommandTimeout = 0;
                //Agrego parametros de la consulta
                if (xpar != null)
                {
                    foreach (SqlParameter p in xpar)
                    {
                        command.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                    }
                }
                cn.Open();
                da = new SqlDataAdapter(command);
                db = new DataSet();
                da.Fill(db);
                cn.Close();
            }
            // Aqui necesito los nombres de las tablas para poder hacer match con el origen de datos 
            // que se pone en la definición del reporte. Para ello la primera tabla de todo conjunto de datos
            // deberá ser una que especifique dichos nombres
            for (var j = 0; j <= db.Tables.Count - 1; j++)
            {
                if (j == 0)
                    continue;
                DataTable table = db.Tables[j];
                string nT = db.Tables[0].Rows[0]["N" + j.ToString().Trim()].ToString();
                table.TableName = nT;
            }
        }
    }



    public static class Globales {
        public const Keys keyhelp = Keys.F2;
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
        private string _UsrId = "";
        public string UsrId
        {
            get { return _UsrId; }
            //set{_CodUser = value;}
        }
        private int _CodCia = -1;
        public int CodCia
        {
            get { return _CodCia; }
            //set{_CadenaConexion = value;}
        }
        private int _CodUser = -1;
        public int CodUser
        {
            get { return _CodUser; }
            //set{_CadenaConexion = value;}
        }
        private int _UsrSexo = -1;
        public int UsrSexo
        {
            get { return _UsrSexo; }
            //set{_CadenaConexion = value;}
        }
        private bool _Otra = false;
        public bool Otra
        {
            get { return _Otra; }
            set{ _Otra = value;}
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
                    string sql = @"SELECT  a.connstring, c.Nombre, c.codigo FROM empresas A 
                                left join (
	                                select usernom, userpwd , codigo,Nombre from usuarios
                                 )C on CAST(usernom as varbinary(100)) = CAST(@nomuser as varbinary) 
                                AND CAST(userpwd as varbinary(100)) = CAST(@pwd as varbinary(100))
                                inner join
                                (
                                select usercod, codcia from Permisos where tipo='E'   
                                 ) B on a.codcia=B.codcia and b.usercod= isnull(c.codigo,0)
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
                    _CadenaConexion = dt.Rows[0][0].ToString();
                    using (SqlConnection cn2 = DAO.Conexion.Conectar())
                    {
                        cn2.Open();
                        cn2.Close();
                    }
                    //si llego hasta este punto es porque si existe y si vale la segunda cadena de conexion
                    _UsrNom = dt.Rows[0][1].ToString();
                    _UsrId = usrx;
                    _CodUser = (int)dt.Rows[0][2];
                    _CodCia = ciax;
                   DFUNC.UsrWinReg(true);
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
