using System.Collections.Generic;
using Planificador.Models;
namespace Planificador.Data.PlanesDeEstudio
{
    public interface IPlanEstudio
    {
        PlanDeEstudios GetPlanEstudio();

        List<Materia> GetListaMaterias();
    }
}
