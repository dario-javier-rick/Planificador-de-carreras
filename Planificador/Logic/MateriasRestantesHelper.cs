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
        public static IEnumerable<Materia> GetMateriasPendientes(string nombre)
        {
            var MateriasDeCarrera = DbContext.GetListaDeMaterias();
            var MateriasDeEstudiante = DbContext.GetListaDeMaterias(nombre);
            return FiltroPorMateria.Filtrar(MateriasDeEstudiante, MateriasDeCarrera);
        }
    }
}