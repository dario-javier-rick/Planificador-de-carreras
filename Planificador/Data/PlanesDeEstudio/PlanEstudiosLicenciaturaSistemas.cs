using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
namespace Planificador.Data.PlanesDeEstudio
{
    public class PlanEstudiosLicenciaturaSistemas : IPlanEstudio
    {
        private List<Materia> Materias;

        public PlanDeEstudios GetPlanEstudio()
        {
            var planDeEstudios = new PlanDeEstudios
            {
                Id = 1,
                Materias = this.GetListaMaterias(),                
            };
            return planDeEstudios;
        }

        public List<Materia> GetListaMaterias()
        {
            if (this.Materias != null)
            {
                return this.Materias;
            }

            this.Materias = new List<Materia>();
            Materia ip = new Materia
            {
                IdMateria = 1,
                Nombre = "Introduccion a la Programacion"
            };
            this.Materias.Add(ip);

            Materia p1 = new Materia
            {
                IdMateria = 2,
                Nombre = "Programacion 1",
                Correlativas = new List<Materia> { ip }
            };
            this.Materias.Add(p1);

            Materia p2 = new Materia
            {
                IdMateria = 3,
                Nombre = "Programacion 2",
                Correlativas = new List<Materia> { p1 }
            };
            this.Materias.Add(p2);

            Materia p3 = new Materia
            {
                IdMateria = 4,
                Nombre = "Programacion 3",
                Correlativas = new List<Materia> { p2 }
            };
            this.Materias.Add(p3);

            Materia im = new Materia
            {
                IdMateria = 5,
                Nombre = "Introduccion a la Matematica",
            };
            this.Materias.Add(im);
            
            Materia lg = new Materia
            {
                IdMateria = 6,
                Nombre = "Logica y teoria de numeros",
                Correlativas = new List<Materia> { im }
            };
            this.Materias.Add(lg);


            Materia md = new Materia
            {
                IdMateria = 7,
                Nombre = "Matematica Discreta",
                Correlativas = new List<Materia> { lg }
            };
            this.Materias.Add(md);

            return this.Materias;
        }
    }
}