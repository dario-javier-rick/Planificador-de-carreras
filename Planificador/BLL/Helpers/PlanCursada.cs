using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.Helpers
{
    public class PLanCursada
    {
        private Dictionary<int, Semestre> _planCursada;

        public PLanCursada()
        {
            this._planCursada = new Dictionary<int, Semestre>();
        }

        public void AgregarSemestre()
        {
            int nuevoSemestre = 1 + this._planCursada.Count;
            this._planCursada.Add(nuevoSemestre, new Semestre());
        }

        public void AgregarMateriaSemestre(int semestre, Materia materia)
        {
            //this._planCursada
        }
    }
}