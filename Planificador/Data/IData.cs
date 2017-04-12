using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planificador.Data
{
    public interface IData<T> where T : class
    {
        IEnumerable<T> GetData();
    }
}
