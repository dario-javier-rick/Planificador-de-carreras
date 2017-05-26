using System.IO;


namespace Planificador.BLL.Constantes

{

    public class Constantes
    {
        public const string NombreArchivo = "Data.txt";
        public static readonly string DataManagerPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\Data";
    }

}