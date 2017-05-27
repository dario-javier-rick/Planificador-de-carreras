using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public interface IDataReader<T> where T : class
    {
        List<T> ListaObj { get; }
        string ToDataLine(T obj);
        T GenerateFromDataLine(string linea);
    }
}
