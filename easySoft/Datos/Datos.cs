using System;
using System.Collections.Generic;
using System.Data;
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
}
