using System.Collections.Generic;
using System.Linq;
using Planificador.Models;

namespace Planificador.BLL.Helpers
{
    public class PlanEstudioRestante
    {
        private int _cod;
        private List<Materia> _materiasPendientes;
        private List<Correlativa> _correlatividades;

        public PlanEstudioRestante(PlanDeEstudio planDeEstudio, List<Materia> materiasPorCursar)
        {
            this._cod = planDeEstudio.Id;
            this._materiasPendientes = materiasPorCursar;
            this._correlatividades = planDeEstudio.Correlativas.ToList();
        }

        public List<Materia> MateriasPendientes()
        {
            return this._materiasPendientes;
        }

        public void CursarMateria(Materia materia)
        {
            List<Materia> aux = new List<Materia>();

            foreach (Materia m in this._materiasPendientes)
            {
                if (!m.Equals(materia))
                {
                    aux.Add(m);
                }
            }

            this._materiasPendientes = aux;
        }

        public List<Correlativa> Correlatividades()
        {
            return this._correlatividades;
        }
    }
}