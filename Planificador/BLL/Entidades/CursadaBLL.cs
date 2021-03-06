﻿using System;
using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class CursadaBLL:IDataReader<Cursada>
    {
        private static CursadaBLL _instancia;
        public List<Cursada> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static CursadaBLL Instance()
        {
            return _instancia ?? (_instancia = new CursadaBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private CursadaBLL()
        {
            ListaObj = new List<Cursada>();
        }

        public string ToDataLine(Cursada obj)
        {
            throw new NotImplementedException();
        }

        public Cursada GenerateFromDataLine(string linea)
        {
            throw new NotImplementedException();
        }
    }
}
