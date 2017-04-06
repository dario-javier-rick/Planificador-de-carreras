using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.Logic
{
    public static class DbContext
    {
        public static List<Materia> GetListaDeMaterias()
        {
            var lista = new List<Materia>();
            var m = new Materia
            {
                IdMateria = 1,
                Nombre = "Proyecto profesional 2"
            };

            lista.Add(m);
            return lista;
        }
    }
}