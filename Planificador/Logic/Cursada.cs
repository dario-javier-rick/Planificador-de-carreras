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
        private Carrera carrera = new Carrera();
        private Materia materia = new Materia();
        private Alumno alumno = new Alumno();

        public Cursada()
        {
        }

        public IEnumerable<Materia> ObtenerPosiblesMateriasACursar(Alumno alumno)
        {
			if (alumno == null)
			{
				return new List<Materia>();
			}
			
			//Me fijo en que carrera / plan de estudios esta el alumno, y obtengo las materias correspondientes
			//TODO: Filtrar por plan de estudios. Patron observer?
	    	IEnumerable <Materia> materiasDeCarrera = MateriasPorCarrera.ListarMateriasLicenciaturaInformatica();

			//Me fijo que materias aprobadas tiene el alumno
            IEnumerable<Materia> materiasAprobadas = alumno.ListarMateriasAprobadas();

			//Devuelvo las que realmente pueden ser cursadas.
			return alumno.ObtenerMateriasQuePuedoCursar(materiasAprobadas, materiasDeCarrera);
		}
    }
}