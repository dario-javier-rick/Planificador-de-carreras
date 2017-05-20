using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Planificador.BLL.Constantes
{
    public class Constantes
    {
        public const string Aprobado = "Aprobado";

        public static readonly string DataManagerPath = AppDomain.CurrentDomain.BaseDirectory;
            //ConfigurationManager.AppSettings["DataManagerPath"];
    }
}