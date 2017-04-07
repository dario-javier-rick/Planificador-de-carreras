using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.Logic
{
    public static class FiltroPorMateria
    {
        public static IEnumerable<Materia> Filtrar(IEnumerable<Materia> materiasAprobadas, IEnumerable<Materia> materiasCarrera)
        {
            var listaDeMaterias = materiasAprobadas.Except(materiasCarrera);
            listaDeMaterias = ActualizarCorrelativasPendientes(listaDeMaterias);
            return listaDeMaterias.Where(x => !x.TieneCorrelativas);
        }

        private static IEnumerable<Materia> ActualizarCorrelativasPendientes(IEnumerable<Materia> materiasRestantes)
        {
            var lista = new List<Materia>();
            foreach (var materia in materiasRestantes)
            {
                //Logica temporal, debe filtrar por lista de correlatividades restantes por materias del conjunto
                if (materia.IdMateria % 2 == 0)
                {
                    lista.Add(materia);
                }
            }
            return lista;
        }
    }
}