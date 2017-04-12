using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.Logic
{
    public class CaminoCritico
    {
        public IEnumerable<Models.Materia> GetCaminoCritico(Planificador.Models.PlanDeEstudios planDeEstudios)
        {
            this.CalcularPesoEnCaminoCritico(planDeEstudios.Materias);
            var a = this.ArmarCaminoCritico(planDeEstudios.Materias);
            return a;
        }

        private IEnumerable<Models.Materia> ArmarCaminoCritico(IEnumerable<Models.Materia> materias)
        {
            var mayorNivel = materias.Max(x => x.Nivel);
            return materias.Where(x => x.Nivel == mayorNivel);
        }
        private void CalcularCaminoCritico(Planificador.Models.PlanDeEstudios planDeEstudios)
        {
            this.CalcularPesoEnCaminoCritico(planDeEstudios.Materias);
        }

        private void CalcularPesoEnCaminoCritico(IEnumerable<Models.Materia> materias, int nivel = 0)
        {
            var tieneMaterias = materias != null && materias.Count() > 0;
            if (tieneMaterias)
            {
                List<Models.Materia> materiasSinCorrelativas = materias.Where(x => x.Correlativas == null || !x.Correlativas.Any()).ToList() ?? new List<Models.Materia>();
                foreach (var materiaSinCorrelativas in materiasSinCorrelativas)
                {
                    materiaSinCorrelativas.Nivel = nivel;
                }

                List<Models.Materia> materiasConCorrelativas = materias.Where(x => x.Correlativas != null && x.Correlativas.Any()).ToList() ?? new List<Models.Materia>();
                foreach (var materiaConCorrelativas in materiasConCorrelativas)
                {
                    var materiasCorrelativasParaBorrar = materiaConCorrelativas.Correlativas.Intersect(materiasSinCorrelativas);
                    materiaConCorrelativas.Correlativas = materiaConCorrelativas.Correlativas.Except(materiasCorrelativasParaBorrar).ToList();
                }

                CalcularPesoEnCaminoCritico(materiasConCorrelativas, ++nivel);
            }
            return;
        }
        /// <summary>
        /// recorro la lista de materias que tienen correlativas
        /// si para una materia especifica en su lista de materias correlativas contiene alguna de la lista de materias sin correlativas
        /// estas se quitan de la lista de materias correlativas.
        /// </summary>
        /// <param name="materiasConCorrelativas"></param>
        /// <param name="materiasSinCorrelativas"></param>
        //private void QuitarCorrelatividades(IEnumerable<Models.Materia> materiasConCorrelativas, IEnumerable<Models.Materia> materiasSinCorrelativas)
        //{
        //    foreach (var materiaConCorrelativas in materiasConCorrelativas)
        //    {
        //        var materiasCorrelativasParaBorrar = materiaConCorrelativas.Correlativas.Intersect(materiasSinCorrelativas);
        //        var nuevas = materiaConCorrelativas.Correlativas.Except(materiasCorrelativasParaBorrar).ToList();

        //        materiaConCorrelativas.Correlativas = nuevas;
        //    }
        //}
    }
}