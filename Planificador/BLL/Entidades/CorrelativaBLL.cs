using System;
using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class CorrelativaBLL:IDataReader<Correlativa>
    {
        private static CorrelativaBLL _instancia;
        public List<Correlativa> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static CorrelativaBLL Instance()
        {
            return _instancia ?? (_instancia = new CorrelativaBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private CorrelativaBLL()
        {
            ListaObj = new List<Correlativa>();
        }
        public string ToDataLine(Correlativa obj)
        {
            throw new NotImplementedException();
        }

        public Correlativa GenerateFromDataLine(string linea)
        {
            throw new NotImplementedException();
        }
    }
}
