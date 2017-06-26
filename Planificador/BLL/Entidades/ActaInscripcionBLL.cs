using System.Collections.Generic;
using Planificador.BLL.Helpers;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class ActaInscripcionBLL : IDataReader<ActaInscripcion>
    {
        //Lazy initialization. Instancio el objeto únicamente cuando lo necesito.
        private static ActaInscripcionBLL _instancia;
        public List<ActaInscripcion> ListaObj { get; }

        public static ActaInscripcionBLL Instance()
        {
            return _instancia ?? (_instancia = new ActaInscripcionBLL());
        }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public ActaInscripcionBLL()
        {
            ListaObj = new List<ActaInscripcion>();
        }

        public ActaInscripcion GenerateFromDataLine(string linea)
        {
            string[] actaArray = linea.Split(',');

            FacadePlanificador fc = new FacadePlanificador();

            Alumno alumno = fc.ObtenerAlumnoPorId(int.Parse(actaArray[2]));
            Carrera carrera = fc.ObtenerCarreraPorId(int.Parse(actaArray[3]));

            ActaInscripcion acta = new ActaInscripcion(alumno,carrera);

            return acta;
        }

        public string ToDataLine(ActaInscripcion actaInscripcion)
        {
            return "[" + nameof(actaInscripcion) + "]," + actaInscripcion.AlumnoInscripto().Id + "," + actaInscripcion.InscriptoEnCarrera().CodigoCarrera;
        }
    }
}