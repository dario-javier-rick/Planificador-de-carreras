using Planificador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.Logic
{
    /// <summary>
    /// Patron Facade. Proveo una interfaz única para manejar la lógica de 3 subsistemas diferentes
    /// </summary>
    public class Cursada
    {
        private Carrera _carrera = new Carrera();
        private Materia _materia = new Materia();
        private Alumno _alumno = new Alumno();

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

            //Me fijo en que carrera / plan de estudios esta el alumno, y obtengo las materias correspondientes
            List<PlanDeEstudios> planesDeEstudios = alumno.PlanesDeEstudios.ToList();

            //TODO: Patron observer? Nico V: noup, observer es para el front
            List<Materia> materiasDeCarreras = new List<Materia>();
            foreach (PlanDeEstudios plan in planesDeEstudios)
            {
                materiasDeCarreras.AddRange(plan.Materias);
            }


            //Me fijo que materias aprobadas tiene el alumno
            IEnumerable<Materia> materiasAprobadas = alumno.ListarMateriasAprobadas();

			//Devuelvo las que realmente pueden ser cursadas.
			return alumno.ObtenerMateriasQuePuedoCursar(materiasAprobadas, materiasDeCarreras);
		}
    }
}