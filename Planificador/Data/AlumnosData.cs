using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
namespace Planificador.Data
{
    public class AlumnosData : IData<Alumno>
    {
        public IEnumerable<Alumno> GetData()
        {
            var dataList = new List<Alumno>
            {
                new Alumno
                {
                    IdUsuario = 1,
                    Nombre = "Dario",
                    Apellido = "Rick",
                    Dni = "37170404",
                   // PlanDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosSistemas }
                },
                new Alumno
                {
                    IdUsuario = 2,
                    Nombre = "Nicolas",
                    Apellido = "Fernandez",
                   // PlanDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosSistemas }
                },

                new Alumno
                {
                    IdUsuario = 3,
                    Nombre = "Nicolas",
                    Apellido = "Videla Rivero",
                    //PlanDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosSistemas, PlanDeEstudiosEconomia }
                },

                new Alumno
                {
                    IdUsuario = 4,
                    Nombre = "Adam",
                    Apellido = "Smith",
                   // PlanDeEstudios = new List<PlanDeEstudios> { PlanDeEstudiosEconomia }
                }
            };
            return dataList;
        }
    }
}