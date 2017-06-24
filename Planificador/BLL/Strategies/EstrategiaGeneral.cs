using System.Collections.Generic;
using System.Linq;
using Planificador.Models;
using Planificador.BLL.Helpers;

namespace Planificador.BLL.Strategies
{
    class EstrategiaGeneral: Strategy
    {
        public override PlanCursada CalcularCaminoMinimo(PlanDeEstudio planEstudio, IEnumerable<Materia> materiasPendientes)
        {
            if (!materiasPendientes.Any())
            {
                return new PlanCursada();
			}
                
            PlanCursada planCursada = new PlanCursada();
            IEnumerable<Materia> materiasAprobadas = planEstudio.Materia.Where(p => !materiasPendientes.Contains(p)).ToList();


            foreach (Materia x in materiasPendientes)
			{
                Semestre semestre = new Semestre();
                if(!x.Correlativa.Any())
                {
                    semestre.AgregarMateria(x);
                }
                else
                {
                    
                }

			}


            return planCursada;
        }

		/* Se crea un plan de cursada vacio para que se llene dentro de la funcion. */
		//this._planCursada = new PLanCursada();

		// CrearPlanCursadaCrudo(_planCursada, _materiasAprobadas, new PlanEstudioRestante(_plan, materiasFaltantes));

		/* Hasta este momento voy a tener una lista PlanCursada cruda. */
		/* Para esto se va pasar una estrategia y ordenara el plan en base a la estrategia. */
		//_strategy.AlgorithmInterface();
		//}

        private void CrearPlanCursadaCrudo(PlanCursada planCursada, List<Materia> materiasAprobadas, PlanEstudioRestante planDeEstudio)
		{
			bool correlatividadCursadas;
			Semestre semestre;

			if (planDeEstudio.MateriasPendientes().Any())
			{
				semestre = new Semestre();
				foreach (Materia x in planDeEstudio.MateriasPendientes())
				{
					correlatividadCursadas = true;
					/*nnn foreach (Materia y in planDeEstudio.Correlatividades())
                    {
                        
                    }*/
				}
			}
		}

	}
}