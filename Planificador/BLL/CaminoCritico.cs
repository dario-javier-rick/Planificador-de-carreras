using System.Collections.Generic;
using System.Linq;
using Planificador.BLL.Helpers;
using Planificador.Models;
using Planificador.BLL.Strategies;

namespace Planificador.BLL
{
    class CaminoCritico
    {
        private PlanDeEstudio _plan;
        private List<Materia> _materiasAprobadas;
        private Strategy _strategy;

        private PlanCursada _planCursada;

        //Constructor
        public CaminoCritico(Alumno alumno)
        {
			FacadePlanificador fc = new FacadePlanificador();
			/* Obtengo la carrera para obtener su plan de estudio. */
			Carrera carrera = fc.ObtenerCarreradeAlumno(alumno);

			/* Obtengo el plan de la carrera para conocer las materias y sus correlativas. */
			_plan = fc.ObtenerPlanEstudioParaCarrera(carrera);

			/* Ahora obtengo un listado de materias aprobadas por el alumno. */
			_materiasAprobadas = fc.ObtenerMateriasAprobadasPara(alumno);
        }

        public void ConfigurarEstrategia(Strategy estrategia)
        {
            this._strategy = estrategia;
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

            planCursada = _strategy.CalcularCaminoMinimo(_plan,materiasFaltantes);
        }


        /* Se crea un plan de cursada vacio para que se llene dentro de la funcion. */
        //this._planCursada = new PLanCursada();

        // CrearPlanCursadaCrudo(_planCursada, _materiasAprobadas, new PlanEstudioRestante(_plan, materiasFaltantes));

        /* Hasta este momento voy a tener una lista PlanCursada cruda. */
        /* Para esto se va pasar una estrategia y ordenara el plan en base a la estrategia. */
        //_strategy.AlgorithmInterface();
        //}

        public void CrearPlanCursadaCrudo(PlanCursada planCursada, List<Materia> materiasAprobadas, PlanEstudioRestante planDeEstudio)
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

        public Dictionary<Materia, int> DiccionarioCriticidad { get; } = new Dictionary<Materia, int>();

        /// <summary>
        /// Contructor viejo para no romper por el momento pero una vez ande lo de arroba este vuela.
        /// </summary>
        public CaminoCritico()
        {

        }

        //public IEnumerable<Models.Materia> GetCaminoCritico(Models.PlanDeEstudio planDeEstudios)
        //{
        //    CalcularPesoEnCaminoCritico(planDeEstudios.Materia);
        //    //var a = ArmarCaminoCritico(planDeEstudios.Materia);
        //    return null;
        //}

        ///* //TODO: Corregir
        //private IEnumerable<Materia> ArmarCaminoCritico(IEnumerable<Materia> materias)
        //{
        //    var mayorNivel = materias.Max(x => x.Nivel);
        //    return materias.Where(x => x.Nivel == mayorNivel);
        //}
        //*/
        //private void CalcularCaminoCritico(Models.PlanDeEstudio planDeEstudios)
        //{
        //    CalcularPesoEnCaminoCritico(planDeEstudios.Materia);
        //}


        ///// <summary>
        ///// Dada una lista de materias, indica el camino crítico y la prioridad a tener en cuenta para cursarlas
        ///// </summary>
        ///// <param name="materias"></param>
        ///// <param name="nivel"></param>
        internal void CalcularPesoEnCaminoCritico(IEnumerable<Materia> materias, int nivel = 0)
        {
            if (!materias.Any())
            {
                return;
            }

            List<Materia> materiasSinCorrelativas = materias.Where(x => x.Correlativas == null || !x.Correlativas.Any()).ToList();
            foreach (var materiaSinCorrelativas in materiasSinCorrelativas)
            {
                //materiaSinCorrelativas.Nivel = nivel;
                DiccionarioCriticidad.Add(materiaSinCorrelativas, nivel);
            }

            List<Materia> materiasConCorrelativas = materias.Where(x => x.Correlativas != null && x.Correlativas.Any()).ToList();
            foreach (var materiaConCorrelativas in materiasConCorrelativas)
            {
                //var materiasCorrelativasParaBorrar = materiaConCorrelativas.Correlativas.Intersect(materiasSinCorrelativas);
                //materiaConCorrelativas.Correlativas = materiaConCorrelativas.Correlativas.Except(materiasCorrelativasParaBorrar).ToList();
            }

            CalcularPesoEnCaminoCritico(materiasConCorrelativas, ++nivel);

        }
        ///// <summary>
        ///// recorro la lista de materias que tienen correlativas
        ///// si para una materia especifica en su lista de materias correlativas contiene alguna de la lista de materias sin correlativas
        ///// estas se quitan de la lista de materias correlativas.
        ///// </summary>
        ///// <param name="materiasConCorrelativas"></param>
        ///// <param name="materiasSinCorrelativas"></param>
        ////private void QuitarCorrelatividades(IEnumerable<Models.Materia> materiasConCorrelativas, IEnumerable<Models.Materia> materiasSinCorrelativas)
        ////{
        ////    foreach (var materiaConCorrelativas in materiasConCorrelativas)
        ////    {
        ////        var materiasCorrelativasParaBorrar = materiaConCorrelativas.Correlativas.Intersect(materiasSinCorrelativas);
        ////        var nuevas = materiaConCorrelativas.Correlativas.Except(materiasCorrelativasParaBorrar).ToList();

        ////        materiaConCorrelativas.Correlativas = nuevas;
        ////    }
        ////}

    }
}