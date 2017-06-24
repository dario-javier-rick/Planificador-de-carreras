using System.Collections.Generic;
using Planificador.Models;
using Planificador.BLL.Helpers;

namespace Planificador.BLL.Strategies
                      
{
    abstract class Strategy
    {
        public abstract PlanCursada CalcularCaminoMinimo(PlanDeEstudio planEstudio, IEnumerable<Materia> materiasPendientes);
    }
}