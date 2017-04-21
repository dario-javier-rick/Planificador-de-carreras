using System.Collections.Generic;
using System.Linq;
using Planificador.Data.Constantes;
using Planificador.Logic;

namespace Planificador.Models
{
    public partial class Alumno
    {
        public static Alumno ObtenerAlumno(string nombreAlumno)
        {
            return Alumnos.ListaAlumnos.FirstOrDefault(alumno => alumno.Nombre == nombreAlumno);
        }

        public List<Materia> ListarMateriasAprobadas()
        {
            List<Materia> materiasAprobadas = new List<Materia>();
            foreach (HistorialAcademico historial in HistorialAcademico)
            {
                if (historial.Estado == Constantes.Aprobado)
                {
                    materiasAprobadas.Add(historial.Materia);
                }
            } 
            return materiasAprobadas;
        }

        public List<Materia> ObtenerMateriasQuePuedoCursar(IEnumerable<Materia> materiasAprobadas, IEnumerable<Materia> materiasDeCarrera)
        {
            List<Materia> materiasSinAprobar = materiasDeCarrera.Except(materiasAprobadas).ToList();

            //De las sin aprobar, saco las que requieren correlativas que no tengo aprobadas
            List<Materia> materiasQuePudenSerCursadas = ObtenerMateriasQueNoRequierenCorrelativas(materiasSinAprobar, materiasAprobadas);

            return materiasQuePudenSerCursadas;
        }

        private List<Materia> ObtenerMateriasQueNoRequierenCorrelativas(List<Materia> materias, IEnumerable<Materia> correlativasAprobadas)
        {
            List<Materia> materiasQueNoRequierenCorrelativas = new List<Materia>();
            foreach (Materia materia in materias)
            {
                foreach (Materia posibleCorrelativa in correlativasAprobadas)
                {
                    if (!materia.Correlativas.Contains(posibleCorrelativa))
                    {
                        materiasQueNoRequierenCorrelativas.Add(materia);
                    }
                }
            }

            return materiasQueNoRequierenCorrelativas;
        }

        /*
		private static List<Materia> ObtenerMateriasSinAprobar(List<Materia> materiasAprobadas, List<Materia> materiasDeCarrera)
		{
			List<Materia> listaDeMateriasSinAprobar = new List<Materia>();
			foreach (Materia materiaDelAlumnoAprobada in materiasAprobadas)
			{
				Materia materiaAprobada = materiasDeCarrera.FirstOrDefault(x => x.Equals(materiaDelAlumnoAprobada));
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
        */
    }
}