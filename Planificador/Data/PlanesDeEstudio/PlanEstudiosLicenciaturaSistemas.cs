using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
namespace Planificador.Data.PlanesDeEstudio
{
    public class PlanEstudiosLicenciaturaSistemas : IPlanEstudio
    {
        private List<Materia> _materias;

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
            if (this._materias != null)
            {
                return this._materias;
            }

            this._materias = new List<Materia>();
            Materia ip = new Materia
            {
                IdMateria = 1,
                Nombre = "Introduccion a la Programacion"
            };
            this._materias.Add(ip);

            Materia p1 = new Materia
            {
                IdMateria = 2,
                Nombre = "Programacion 1",
                Correlativas = new List<Materia> { ip }
            };
            this._materias.Add(p1);

            Materia p2 = new Materia
            {
                IdMateria = 3,
                Nombre = "Programacion 2",
                Correlativas = new List<Materia> { p1 }
            };
            this._materias.Add(p2);

            Materia p3 = new Materia
            {
                IdMateria = 4,
                Nombre = "Programacion 3",
                Correlativas = new List<Materia> { p2 }
            };
            this._materias.Add(p3);

            Materia im = new Materia
            {
                IdMateria = 5,
                Nombre = "Introduccion a la Matematica",
            };
            this._materias.Add(im);
            
            Materia lg = new Materia
            {
                IdMateria = 6,
                Nombre = "Logica y teoria de numeros",
                Correlativas = new List<Materia> { im }
            };
            this._materias.Add(lg);


            Materia md = new Materia
            {
                IdMateria = 7,
                Nombre = "Matematica Discreta",
                Correlativas = new List<Materia> { lg }
            };
            this._materias.Add(md);

            return this._materias;
        }

    }
}