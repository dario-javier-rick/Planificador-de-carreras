using System.Collections.Generic;
using Planificador.Data.PlanesDeEstudio;
using Planificador.Models;

namespace Planificador.Data
{

    /// <summary>
    /// Clase accesoria para cargar alumnos
    /// </summary>
    public class Alumnos : IData<Alumno>
    {
        private static readonly List<Alumno> ListaAlumnos = new List<Alumno> {

            new Alumno
            {
                IdAlumno = 1,
                Nombre = "Dario",
                Apellido = "Rick",
                Dni = 37170404,
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanEstudiosLicenciaturaSistemas.GetPlanEstudio() }
                //HistorialAcademico = new List<HistorialAcademico> { new HistorialAcademico() }
            },

            new Alumno
            {
                IdAlumno = 2,
                Nombre = "Nicolas",
                Apellido = "Fernandez",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanEstudiosLicenciaturaSistemas.GetPlanEstudio() }
            },

            new Alumno
            {
                IdAlumno = 3,
                Nombre = "Nicolas V",
                Apellido = "Videla Rivero",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanEstudiosLicenciaturaSistemas.GetPlanEstudio(), PlanEstudiosLicenciaturaEconomia.GetPlanEstudio() }
            },

            new Alumno
            {
                IdAlumno = 4,
                Nombre = "Adam",
                Apellido = "Smith",
                PlanesDeEstudios = new List<PlanDeEstudios> { PlanEstudiosLicenciaturaEconomia.GetPlanEstudio() }
            },

            new Alumno
            {
                IdAlumno = 5,
                Nombre = "Prueba",
                Apellido = "Test",
                Dni = 34123123,
                PlanesDeEstudios = new List<PlanDeEstudios> { }
            },

        };

        public IEnumerable<Alumno> GetData()
        {
            return ListaAlumnos;
        }

    }


    /// <summary>
    /// Clase accesoria para cargar carreras
    /// </summary>
    public class Carreras : IData<Carrera>
    {
        public static Carrera LicenciaturaSistemas = new Carrera
        {
            IdCarrera = 1,
            Nombre = "Licenciatura en Sistemas",
            PlanesDeEstudios = new List<PlanDeEstudios> { PlanEstudiosLicenciaturaSistemas.GetPlanEstudio() }
        };

        public static Carrera LicenciaturaEconomia = new Carrera
        {
            IdCarrera = 2,
            Nombre = "Licenciatura en Economía",
            PlanesDeEstudios = new List<PlanDeEstudios> { PlanEstudiosLicenciaturaEconomia.GetPlanEstudio() }
        };

        public IEnumerable<Carrera> GetData()
        {
            return new List<Carrera> { LicenciaturaEconomia, LicenciaturaSistemas };
        }
    }

}