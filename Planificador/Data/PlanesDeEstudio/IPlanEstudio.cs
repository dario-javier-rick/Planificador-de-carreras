using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planificador.Models;
namespace Planificador.Data.PlanesDeEstudio
{
    public interface IPlanEstudio
    {
        PlanDeEstudios GetPlanEstudio();

        List<Materia> GetListaMaterias();
    }
}
