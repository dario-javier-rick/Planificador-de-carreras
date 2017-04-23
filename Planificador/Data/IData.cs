using System.Collections.Generic;

namespace Planificador.Data
{
    public interface IData<T> where T : class
    {
        IEnumerable<T> GetData();
    }
}
