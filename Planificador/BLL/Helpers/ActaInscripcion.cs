using Planificador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.BLL.Helpers
{
    public class ActaInscripcion
    {
        private Alumno _alumno { get; set; }
        private Carrera _carrera { get; set; }

        public ActaInscripcion(Alumno alumno, Carrera carrera)
        {
            this._alumno = alumno;
            this._carrera = carrera;
        }

        public Alumno AlumnoInscripto()
        {
            return _alumno;
        }

        public Carrera InscriptoEnCarrera()
        {
            return _carrera;
        }
    }
}