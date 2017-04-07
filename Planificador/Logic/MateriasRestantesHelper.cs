using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
using Planificador.Logic;

namespace Planificador.Logic
{
    public static class MateriasRestantesHelper 
    {
        public static IEnumerable<Materia> GetMateriasPendientes(Alumno Alumno)
        {
			IEnumerable<Materia> MateriasDeLaCarrera = MateriasPorCarrera.ListaMateriasLicenciaturaInformatica();
			IEnumerable<Materia> MateriasDelEstudiante = MateriasPorCarrera.ListaMateriasLicenciaturaInformatica();
            return FiltroPorMateria.ObtenerMateriasQuePudenSerCursadas(MateriasDelEstudiante, MateriasDeLaCarrera);
        }
    }
}