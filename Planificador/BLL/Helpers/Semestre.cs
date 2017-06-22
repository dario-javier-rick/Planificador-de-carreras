using Planificador.Models;
using System.Collections.Generic;

namespace Planificador.BLL.Helpers
{
    public class Semestre
    {
        private List<Materia> _materias;

        public Semestre()
        {
            this._materias = new List<Materia>();
        }

        public void AgregarMateria(Materia materia)
        {
            this._materias.Add(materia);
        }
    }
}