using Planificador.Models;
using System.Collections.Generic;
using System.Linq;

namespace Planificador.Logic
{
    /// <summary>
    /// Patron Facade. Proveo una interfaz única para manejar la lógica de  subsistemas diferentes
    /// </summary>
    public class Cursada
    {
        private Carrera _carrera = new Carrera();
        private Materia _materia = new Materia();
        private Alumno _alumno = new Alumno();
        public CaminoCritico CaminoCritico { get; } = new CaminoCritico();

        public Cursada()
        {
        }

        /// <summary>
        /// Dado un alumno, devuelve las materias que puede cursar teniendo en cuenta las de los planes de estudios, las ya cursadas, las que le faltan y las correlativas.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public IEnumerable<Materia> ObtenerPosiblesMateriasACursar(Alumno alumno)
        {
            if (alumno == null)
            {   
                return Enumerable.Empty<Materia>();
            }

            //TODO: Patron observer? Nico V: noup, observer es para el front

            //Recorro todos los planes de estudios del alumno, y obtengo las materias correspondientes
            List<PlanDeEstudios> planesDeEstudios = alumno.PlanesDeEstudios.ToList();
            HashSet<Materia> materiasDeCarreras = new HashSet<Materia>();

            foreach (PlanDeEstudios plan in planesDeEstudios)
            {
                foreach (Materia materia in plan.Materias)
                {
                    materiasDeCarreras.Add(materia);
                }
            }

            //Me fijo que materias aprobadas tiene el alumno
            IEnumerable<Materia> materiasAprobadas = alumno.ListarMateriasAprobadas();

			//Devuelvo las que realmente pueden ser cursadas.
			return alumno.ObtenerMateriasQuePuedoCursar(materiasAprobadas, materiasDeCarreras);
		}

        public Dictionary<Materia,int> CalcularPesoEnCaminoCritico(List<Materia> materias)
        {
            CaminoCritico.CalcularPesoEnCaminoCritico(materias);
            return CaminoCritico.DiccionarioCriticidad;
        }
    }
}