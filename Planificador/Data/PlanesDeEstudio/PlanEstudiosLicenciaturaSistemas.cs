using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.Data.PlanesDeEstudio
{
    public class PlanEstudiosLicenciaturaSistemas : IPlanEstudio
    {
        private static List<Materia> _materias;

        PlanDeEstudios IPlanEstudio.GetPlanEstudio()
        {
            return GetPlanEstudio();
        }

        List<Materia> IPlanEstudio.GetListaMaterias()
        {
            return GetListaMaterias();
        }

        public static PlanDeEstudios GetPlanEstudio()
        {
            var planDeEstudios = new PlanDeEstudios
            {
                Id = 1,
                Materias = GetListaMaterias(),   
                Vigente = true
            };
            return planDeEstudios;
        }

        public static List<Materia> GetListaMaterias()
        {
            if (_materias != null)
            {
                return _materias;
            }

            _materias = new List<Materia>();

            Materia ip = new Materia
            {
                IdMateria = 1,
                Nombre = "Introduccion a la Programacion"
            };
            _materias.Add(ip);

            Materia p1 = new Materia
            {
                IdMateria = 2,
                Nombre = "Programacion 1",
                Correlativas = new List<Materia> { ip }
            };
            _materias.Add(p1);

            Materia p2 = new Materia
            {
                IdMateria = 3,
                Nombre = "Programacion 2",
                Correlativas = new List<Materia> { p1 }
            };
            _materias.Add(p2);

            Materia p3 = new Materia
            {
                IdMateria = 4,
                Nombre = "Programacion 3",
                Correlativas = new List<Materia> { p2 }
            };
            _materias.Add(p3);

            Materia im = new Materia
            {
                IdMateria = 5,
                Nombre = "Introduccion a la Matematica",
            };
            _materias.Add(im);
            
            Materia lg = new Materia
            {
                IdMateria = 6,
                Nombre = "Logica y teoria de numeros",
                Correlativas = new List<Materia> { im }
            };
            _materias.Add(lg);


            Materia md = new Materia
            {
                IdMateria = 7,
                Nombre = "Matematica Discreta",
                Correlativas = new List<Materia> { lg }
            };
            _materias.Add(md);

            return _materias;
        }

    }
}