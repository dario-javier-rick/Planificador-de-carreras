using Planificador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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