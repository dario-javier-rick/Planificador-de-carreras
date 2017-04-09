using System;
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
    }
}