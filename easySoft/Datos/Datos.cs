using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DataLoggin
    {
        public DataTable Empresas() {
           return  DLIB.Globales.Parametros.connSql.TraerTabla("LOGGIN_001");
        }
    }
    public class DataLobby
    {
        List<SqlParameter> MyPar = new List<SqlParameter>();
        public DataTable FormInfo( string xcod)
        {
            MyPar.Clear();
            MyPar.Add(new SqlParameter("@codForm", xcod));
            return DLIB.Globales.Parametros.connSql.TraerTabla("LOBBY_001", MyPar,true);
        }
    }
}
