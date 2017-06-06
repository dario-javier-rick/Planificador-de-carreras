using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.DTO
{
    public class PlanificadorCaminoMinimoDTO
    {
        public Alumno alumno { get; set; }
        public IEnumerable<Materia> materiasAprobadas { get; set; }
        public Dictionary<int, IEnumerable<Materia>> caminoMinimo{ get; set; }

        public PlanificadorCaminoMinimoDTO(string nombreAlumno)
        {
            alumno = new Alumno {Nombre = nombreAlumno};
        }
    }
}