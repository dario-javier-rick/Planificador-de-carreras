using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Data.PlanesDeEstudio;
using Planificador.Models;
namespace Planificador.Data
{
    public class AlumnosData : IData<Alumno>
    {
        private PlanEstudiosLicenciaturaSistemas _licenciaturaSistemas;
        private PlanEstudiosLicenciaturaEconomia _licentuEconomia;

        public IEnumerable<Alumno> GetData()
        {
            var dataList = new List<Alumno>
            {
                new Alumno
                {
                    IdAlumno = 1,
                    Nombre = "Dario",
                    Apellido = "Rick",
                    Dni = "37170404",
                    PlanesDeEstudios = new List<PlanDeEstudios> { _licenciaturaSistemas.GetPlanEstudio() }
                },
                new Alumno
                {
                    IdAlumno = 2,
                    Nombre = "Nicolas",
                    Apellido = "Fernandez",
                    PlanesDeEstudios = new List<PlanDeEstudios> { _licenciaturaSistemas.GetPlanEstudio() }
                },

                new Alumno
                {
                    IdAlumno = 3,
                    Nombre = "Nicolas",
                    Apellido = "Videla Rivero",
                    PlanesDeEstudios = new List<PlanDeEstudios> { _licenciaturaSistemas.GetPlanEstudio(), _licentuEconomia.GetPlanEstudio() }
                },

                new Alumno
                {
                    IdAlumno = 4,
                    Nombre = "Adam",
                    Apellido = "Smith",
                    PlanesDeEstudios = new List<PlanDeEstudios> { _licentuEconomia.GetPlanEstudio() }
                }
            };
            return dataList;
        }
    }
}