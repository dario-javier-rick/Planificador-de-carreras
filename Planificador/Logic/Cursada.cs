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
			//Me fijo en que carrera / plan de estudios esta el alumno, y obtengo las materias correspondientes
	    	IEnumerable <Materia> MateriasDeLaCarrera = MateriasPorCarrera.ListaMateriasLicenciaturaInformatica();
			//TODO: Filtrar por plan de estudios. Patron observer?

			//Me fijo que materias tiene el alumno
            IEnumerable<Materia> MateriasDelEstudiante = alumno.ListarMateriasAprobadas();

			//Devuelvo las que realmente peuden ser cursadas. TODO: Este metodo deberia ser parte de Alumno?
            return FiltroPorMateria.ObtenerMateriasQuePudenSerCursadas(MateriasDelEstudiante, MateriasDeLaCarrera);
        }
    }
}