using System;
using Planificador.BLL.Entidades;

namespace Planificador.BLL.Factory
{

    /// <summary>
    /// Factory concreta. Genera Singletons de BLL correspondientes
    /// </summary>
    public class FactoryEntidades : BLLFactory
    {
        public override AlumnoBLL CrearAlumnoBLL()
        {
            return AlumnoBLL.Instance;
        }

        public override CarreraBLL CrearCarreraBLL()
        {
            return CarreraBLL.Instance();
        }

        public override CorrelativaBLL CrearCorrelativaBLL()
        {
            return CorrelativaBLL.Instance();
        }

        public override CursadaBLL CrearCursadaBLL()
        {
            return CursadaBLL.Instance();
        }

        public override DocenteBLL CrearDocenteBLL()
        {
            return DocenteBLL.Instance();
        }

        public override LibretaBLL CrearLibretaBLL()
        {
            return LibretaBLL.Instance();
        }

        public override MateriaBLL CrearMateriaBLL()
        {
            return MateriaBLL.Instance();
        }

        public override PlanDeEstudioBLL CrearPlanDeEstudioBLL()
        {
            return PlanDeEstudioBLL.Instance();
        }

        public override ActaInscripcionBLL CrearActaInscipcionBLL()
        {
            return ActaInscripcionBLL.Instance();
        }
    }
}