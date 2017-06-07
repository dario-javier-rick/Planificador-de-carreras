using System;

namespace Planificador.BLL.Entidades
{
    /// <summary>
    /// Abstract Factory.
    /// </summary>
    public abstract class BLLFactory
    {
        public abstract AlumnoBLL CrearAlumnoBLL();
        public abstract CarreraBLL CrearCarreraBLL();
        public abstract CorrelativaBLL CrearCorrelativaBLL();
        public abstract CursadaBLL CrearCursadaBLL();
        public abstract DocenteBLL CrearDocenteBLL();
        public abstract LibretaBLL CrearLibretaBLL();
        public abstract MateriaBLL CrearMateriaBLL();
        public abstract PlanDeEstudioBLL CrearPlanDeEstudioBLL();
        public abstract ActaInscripcionBLL CrearActaInscipcionBLL();
    }
}