using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planificador.Models
{
    public partial class Materia
    {
        public int Nivel { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Materia item = obj as Materia;

            if (item == null)
            {
                return false;
            }

            return this.Nombre.Equals(item.Nombre);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}