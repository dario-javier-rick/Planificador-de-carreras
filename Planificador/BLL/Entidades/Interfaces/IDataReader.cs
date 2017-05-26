namespace Planificador.BLL.Entidades
{
    public interface IDataReader<T> where T : class
    {
        string ToDataLine(T obj);
        T GenerateFromDataLine(string linea);
    }
}
