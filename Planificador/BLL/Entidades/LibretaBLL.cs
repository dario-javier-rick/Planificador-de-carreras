using System;
using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class LibretaBLL: IDataReader<Libreta>
    {
        private static LibretaBLL _instancia;
        public List<Libreta> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static LibretaBLL Instance()
        {
            return _instancia ?? (_instancia = new LibretaBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private LibretaBLL()
        {
            ListaObj = new List<Libreta>();
        }

        public string ToDataLine(Libreta obj)
        {
            throw new NotImplementedException();
        }

        public Libreta GenerateFromDataLine(string linea)
        {
            throw new NotImplementedException();
        }
    }
}
