using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.Models
{
    public partial class Materia
    {
        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            Materia item = obj as Materia;

            if (item == null)
            {
                return false;
            }

            return this.Nombre.Equals(item.Nombre);
        }
    }
}