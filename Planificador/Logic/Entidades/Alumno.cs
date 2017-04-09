﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.Models
{
    public partial class Alumno
    {
		public static Alumno ObtenerAlumno(string nombreAlumno){
			return new Alumno { IdUsuario = 1, Nombre = nombreAlumno }; //TODO: Validar si el alumno existe en alguna DB?
		}

		public List<Materia> ListarMateriasAprobadas() {
			return new List<Materia>(); //TODO: Obtener realmente las materias que tiene aprobadas, y no devolver una lista vacia
		}

		public List<Materia> ObtenerMateriasQuePuedoCursar(IEnumerable<Materia> materiasAprobadas, IEnumerable<Materia> materiasDeCarrera) { 
			List<Materia> materiasSinAprobar = materiasDeCarrera.Except(materiasAprobadas).ToList();
			List<Materia> materiasSinAprobarSinCorrelativasDeMateriasAprobadas = null; //TODO QuitarCorrelativasDeMateriasAprobadas(materiasSinAprobar);
			//List<Materia> materiasQuePudenSerCursadas = materiasSinAprobarSinCorrelativasDeMateriasAprobadas.Where(x => !x.Correlativas.Any()).ToList();
			return materiasSinAprobar;//materiasQuePudenSerCursadas;
		}

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
    }
}