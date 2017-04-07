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
            var MateriasDeLaCarrera = DbContext.GetListaDeMaterias();
            string lalalal = "lalalalal";
            var MateriasDelEstudiante = DbContext.GetListaDeMaterias(lalalal);
            return FiltroPorMateria.ObtenerMateriasQuePudenSerCursadas(MateriasDelEstudiante, MateriasDeLaCarrera);
        }
    }
}