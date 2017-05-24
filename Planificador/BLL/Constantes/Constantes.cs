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

        //public static readonly string DataManagerPath = AppDomain.CurrentDomain.BaseDirectory;            
        public static readonly string DataManagerPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName;
        //ConfigurationManager.AppSettings["DataManagerPath"];
    }
}