using System.Collections.Generic;
using System.Linq;
using Planificador.Models;
using Planificador.BLL.Helpers;

namespace Planificador.BLL.Strategies
{
    class EstrategiaGeneral : Strategy
    {
        public override PlanCursada CalcularCaminoMinimo(PlanDeEstudio planEstudio, IEnumerable<Materia> materiasPendientes, params string[] args)
        {
            PlanCursada planCursada = new PlanCursada();

            if (!materiasPendientes.Any())
            {
                return planCursada;
            }

            IEnumerable<Materia> materiasAprobadas = planEstudio.Materia.Where(p => !materiasPendientes.Contains(p)).ToList();
            AgregarMateriasPorSemestre(planCursada, planEstudio, materiasAprobadas);

            return planCursada;
        }

        private static void AgregarMateriasPorSemestre
        (
        PlanCursada planCursada,
        PlanDeEstudio planDeEstudio,
        IEnumerable<Materia> materiasAprobadas,
        int nivel = 1
        )
        {
            List<Materia> materiasPlanDeEstudios = planDeEstudio.Materia.ToList();
            List<Materia> materiasSinCorrelativas = (from mat in materiasPlanDeEstudios
                                                     where 
                                                     //Que no este aprobada
                                                     !materiasAprobadas.Contains(mat)
                                                     //Que segun su plan de estudios, no tenga tenga correlativas
                                                     && 
                                                     ( !mat.RequiereCursar.Select(corr => corr.IdPlanEstudio == planDeEstudio.Id).Any()
                                                     //O que de sus correlativas, todas esten aprobadas
                                                     || mat.RequiereCursar.Any(corr => corr.IdPlanEstudio == planDeEstudio.Id && materiasAprobadas.Any(c => c.Id == corr.IdMateria))
                                                     )
                                                     select mat).ToList();

            if (!materiasSinCorrelativas.Any())
            {
                return;
            }

            planCursada.AgregarSemestre();

            foreach (Materia m in materiasSinCorrelativas)
            {
                planCursada.AgregarMateriaSemestre(nivel, m);
            }

            AgregarMateriasPorSemestre(planCursada, planDeEstudio, materiasSinCorrelativas.Union(materiasAprobadas), ++nivel);

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