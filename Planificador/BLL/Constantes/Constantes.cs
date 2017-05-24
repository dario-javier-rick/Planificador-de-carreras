using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Planificador.BLL.Constantes
{
    public class Constantes
    {
        public const string Aprobado = "Aprobado";

        //public static readonly string DataManagerPath = AppDomain.CurrentDomain.BaseDirectory;            
        public static readonly string DataManagerPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        //ConfigurationManager.AppSettings["DataManagerPath"];
    }
}