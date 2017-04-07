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
            var listaDeMateriasSinAprobar = new List<Materia>();
            foreach (var materiaDelAlumnoAprobada in materiasAprobadas)
            {
                var materiaAprobada = materiasDeCarrera.FirstOrDefault(x => x.Equals(materiaDelAlumnoAprobada));
                if (materiaAprobada != null)
                {
                    foreach (var materiaDeCarrera in materiasDeCarrera)
                    {
                        if (materiaDeCarrera.Correlativas.Contains(materiaAprobada))
                        {
                            materiaDeCarrera.Correlativas.Remove(materiaDeCarrera);
                            listaDeMateriasSinAprobar.Add(materiaDeCarrera);
                        }
                    }
                }
            }

            return listaDeMateriasSinAprobar;
        }
    }
}