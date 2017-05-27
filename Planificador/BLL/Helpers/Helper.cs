using System;

namespace Planificador.BLL.Helpers
{
    public class Helper
    {
        public static string ObtenerDirectorioProyecto()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}