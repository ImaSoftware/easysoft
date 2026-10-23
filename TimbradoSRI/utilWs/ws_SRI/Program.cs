using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws_SRI
{
    class Program
    {
         static void Main(string[] args)
        {
            //Salida directa si no tiene los argumentos necesarios
            if (args.Length != 6) { Environment.Exit(-1); }
            //Argumentos
            string urlDestino = args[0].ToString();
            string metodoDestino = args[1].ToString();
            string argumento = args[2].ToString();
            Net_A.cons_Server obj = new Net_A.cons_Server();
            obj.consumirServicio(metodoDestino, argumento);
        }
    }
}
