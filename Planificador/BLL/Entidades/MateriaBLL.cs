using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class MateriaBLL
    {
        public static Materia CrearMateria(string nombre)
        {
            return new Materia { Nombre=nombre};
        }

        public static bool Misma(Materia ma, Materia materia)
        {
            if (ma.Nombre.Equals(materia.Nombre))
            {
                return true;
            }
            return false;
        }
    }
}