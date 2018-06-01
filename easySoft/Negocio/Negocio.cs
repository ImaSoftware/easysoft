using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Lobby
    {
        Datos.DataLobby CapaDatos = new Datos.DataLobby();
        public DLIB.FrmInfo getFrmInfo(string xcod) {

            //En este caso no hay validaciones  porque para que le puedan haber hecho clik debe de existir
            DLIB.FrmInfo ret = new DLIB.FrmInfo();//declaracion de entidad
            ret.LLenarInfo(CapaDatos.FormInfo(xcod));// se llena entidad usando capaDatos
            return ret;
            
        }
    }
}
