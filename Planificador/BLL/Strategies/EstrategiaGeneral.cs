using System.Collections.Generic;
using System.Linq;
using Planificador.Models;
using Planificador.BLL.Helpers;

namespace Planificador.BLL.Strategies
{
    class EstrategiaGeneral : Strategy
    {
        public override PlanCursada CalcularCaminoMinimo(PlanDeEstudio planEstudio, IEnumerable<Materia> materiasPendientes)
        {
            if (!materiasPendientes.Any())
            {
                return new PlanCursada();
            }

            IEnumerable<Materia> materiasAprobadas = planEstudio.Materia.Where(p => !materiasPendientes.Contains(p)).ToList();

            PlanCursada planCursada = new PlanCursada();

            AgregarMateriasPorSemestre(planCursada, null, 0, planEstudio, materiasPendientes);


            return planCursada;
        }

        private static void AgregarMateriasPorSemestre
        (
        PlanCursada planCursada,
        Semestre semestre,
        int nivel,
        PlanDeEstudio planDeEstudio, //Del plan de estudio dependen las correlatividades 
        IEnumerable<Materia> materiasPendientes
        )
        {
            foreach (Materia x in materiasPendientes)
            {
                if (!x.Correlativas.Any()) //Verifico correlativas segun plan de estudios
                {
                    if (semestre == null)
                    {
                        semestre = new Semestre();
                    }
                    semestre.AgregarMateria(x);
                }
                else
                {
                    var materiasRequeridas = materiasPendientes; // TODO: Hacer where y filtrar por correlativas segun plan de estudios 
                    Semestre proximoSemestre = new Semestre();
                    AgregarMateriasPorSemestre(planCursada,proximoSemestre,nivel++,planDeEstudio, materiasRequeridas);
                }
            }
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