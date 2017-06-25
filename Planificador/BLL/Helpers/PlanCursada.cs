using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Helpers
{
    public class PlanCursada
    {
        private Dictionary<int, Semestre> _planCursada;

        public PlanCursada()
        {
            this._planCursada = new Dictionary<int, Semestre>();
        }

        public void AgregarSemestre()
        {
            int nuevoSemestre = 1 + this._planCursada.Count;
            _planCursada.Add(nuevoSemestre, new Semestre());
        }

        public void AgregarMateriaSemestre(int semestre, Materia materia)
        {
            _planCursada[semestre].AgregarMateria(materia);
        }
    }
}