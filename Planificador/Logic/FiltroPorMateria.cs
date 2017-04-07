using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.Logic
{
    public static class FiltroPorMateria
    {
        public static IEnumerable<Materia> ObtenerMateriasQuePudenSerCursadas(IEnumerable<Materia> materiasAprobadas, IEnumerable<Materia> materiasDeCarrera)
        {
            var materiasSinAprobar = materiasDeCarrera.Except(materiasAprobadas);
            var materiasSinAprobarSinCorrelativasDeMateriasAprobadas = QuitarCorrelativasDeMateriasAprobadas(materiasSinAprobar);
            var materiasQuePudenSerCursadas = materiasSinAprobarSinCorrelativasDeMateriasAprobadas.Where(x => !x.Correlativas.Any());
            return materiasQuePudenSerCursadas;  
        }

        private static IEnumerable<Materia> ObtenerMateriasSinAprobar(List<Materia> materiasAprobadas, List<Materia> materiasDeCarrera)
        {
            var lista = new List<Materia>();
            foreach (var materiaAprobada in materiasAprobadas)
            {

                foreach (var materiaDeCarrera in materiasDeCarrera)
                {
                    if (materiasDeCarrera.Equals(materiaAprobada))
                    {
                        materiasDeCarrera.Remove(materiaDeCarrera);
                    }
                }
            }
            return lista;
        }

        private static IEnumerable<Materia> QuitarCorrelativasDeMateriasAprobadas(IEnumerable<Materia> materiasRestantes)
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