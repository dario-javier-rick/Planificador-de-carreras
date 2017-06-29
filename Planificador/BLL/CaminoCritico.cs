using System.Collections.Generic;
using System.Linq;
using Planificador.BLL.Helpers;
using Planificador.Models;
using Planificador.BLL.Strategies;

namespace Planificador.BLL
{
    class CaminoCritico
    {
        private readonly PlanDeEstudio _plan;
        private readonly List<Materia> _materiasAprobadas;
        private Strategy _strategy;

        //Constructor
        public CaminoCritico(Alumno alumno)
        {
			FacadePlanificador fc = new FacadePlanificador();
			/* Obtengo la carrera para obtener su plan de estudio. */
            Carrera carrera = fc.ObtenerCarrerasDeAlumno(alumno).FirstOrDefault();

			/* Obtengo el plan de la carrera para conocer las materias y sus correlativas. */
			_plan = fc.ObtenerPlanEstudioParaCarrera(carrera);

			/* Ahora obtengo un listado de materias aprobadas por el alumno. */
			_materiasAprobadas = fc.ObtenerMateriasAprobadasPara(alumno);
        }

        public void ConfigurarEstrategia(Strategy estrategia)
        {
            _strategy = estrategia;
        }

        public void Calcular()
        {
			/* Obtengo las materias que faltan cursar para armar el plan de estudio que me queda por completar. */
			List<Materia> materiasFaltantes = new List<Materia>();
			foreach (Materia mat in _plan.Materia)
			{
				if (!_materiasAprobadas.Exists(x => x.Equals(mat)))
				{
					materiasFaltantes.Add(mat);
				}
			}

            _strategy.CalcularCaminoMinimo(_plan,materiasFaltantes);
        }

    }
}