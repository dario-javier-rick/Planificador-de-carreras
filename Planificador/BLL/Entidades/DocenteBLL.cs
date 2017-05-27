using System;
using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class DocenteBLL: IDataReader<Docente>
    {
        private static DocenteBLL _instancia;
        public List<Docente> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static DocenteBLL Instance()
        {
            return _instancia ?? (_instancia = new DocenteBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private DocenteBLL()
        {
            ListaObj = new List<Docente>();
        }

        public string ToDataLine(Docente obj)
        {
            throw new NotImplementedException();
        }

        public Docente GenerateFromDataLine(string linea)
        {
            throw new NotImplementedException();
        }
    }
}
