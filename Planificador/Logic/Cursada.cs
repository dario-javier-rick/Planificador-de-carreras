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

        public IEnumerable<Materia> obtenerPosiblesMateriasACursar(Alumno alumno)
        {
            IEnumerable<Materia> MateriasDeLaCarrera = MateriasPorCarrera.ListaMateriasLicenciaturaInformatica();
            IEnumerable<Materia> MateriasDelEstudiante = MateriasPorCarrera.ListaMateriasLicenciaturaInformatica();
            return FiltroPorMateria.ObtenerMateriasQuePudenSerCursadas(MateriasDelEstudiante, MateriasDeLaCarrera);
        }
    }
}