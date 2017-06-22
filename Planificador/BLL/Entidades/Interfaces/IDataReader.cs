using System.Collections.Generic;

namespace Planificador.BLL.Entidades
{
    public interface IDataReader<T> where T : class
    {
        List<T> ListaObj { get; }
        string ToDataLine(T obj);
        T GenerateFromDataLine(string linea);
    }
}
