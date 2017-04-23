using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.Data.PlanesDeEstudio
{
    public class PlanEstudiosLicenciaturaEconomia : IPlanEstudio
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

            Materia ie = new Materia
            {
                IdMateria = 1,
                Nombre = "Introduccion a la Economía"
            };
            _materias.Add(ie);

            Materia ec = new Materia
            {
                IdMateria = 2,
                Nombre = "Economia Clasica"
            };
            _materias.Add(ec);

            Materia ek = new Materia
            {
                IdMateria = 1,
                Nombre = "Economia Keynesiana"
            };
            _materias.Add(ek);

            return _materias;
        }

    }
}