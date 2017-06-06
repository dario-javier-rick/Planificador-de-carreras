using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.BLL.DTO;

namespace Planificador.BLL.Handler
{
    public class AlumnoHandler : HandlerBase
    {
        public override void ProcesarPedido(PlanificadorCaminoMinimoDTO planificador)
        {
            FacadePlanificador fc = new FacadePlanificador();
            planificador.alumno = fc.ObtenerAlumnos().Where(a => a.Nombre = planificador.alumno.Nombre).FirstOrDefault();
        }
    }
}