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

            //TODO: Sacar if
            if (!materiasQuePudenSerCursadas.Any())
            {
                Materia m = new Materia();
                m.Nombre = "El alumno no esta registrado en ningun plan de estudios";
                materiasQuePudenSerCursadas.Add(m);
            }

            return materiasQuePudenSerCursadas;
        }

        private List<Materia> ObtenerMateriasQueNoRequierenCorrelativas(List<Materia> materiasNoCursadas, IEnumerable<Materia> materiasAprobadas)
        {
            List<Materia> materiasQueNoRequierenCorrelativas = new List<Materia>();
            foreach (Materia materia in materiasNoCursadas)
            {
                if (materia.Correlativas.Any())
                {
                    //Valido si aprobe las correlativas
                    List<Materia> correlativas = materia.Correlativas.ToList();
                    int indice = 0;
                    bool ingresaMateria = true;

                    while(ingresaMateria == true && indice < correlativas.Count)
                    {
                        if (!materiasAprobadas.Contains(correlativas[indice]))
                        {
                            ingresaMateria = false;
                        }

                        indice++;
                    }

                    if (ingresaMateria)
                    {
                        materiasQueNoRequierenCorrelativas.Add(materia);
                    }

                }
                else
                {
                    materiasQueNoRequierenCorrelativas.Add(materia);
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