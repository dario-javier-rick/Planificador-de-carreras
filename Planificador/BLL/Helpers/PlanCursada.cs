using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.Helpers
{
    public class PLanCursada
    {
        private Dictionary<int, List<Materia>> _planCursada;

        public PLanCursada()
        {
            this._planCursada = new Dictionary<int, List<Materia>>();
        }

        public void AgregarSemestre()
        {
            int nuevoSemestre = 1 + this._planCursada.Count;
            this._planCursada.Add(1, new List<Materia>());
        }

        public void AgregarMateriaSemestre(int semestre, Materia materia)
        {
            //this._planCursada
        }
    }
}