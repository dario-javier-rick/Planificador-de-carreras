using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
using Planificador.BLL.Entidades;

namespace Planificador.BLL
{
    public class GeneradorPlanEstudio
    {

        /* Nicolás Daniel Fenández, 17/052017, Metodo para poder conocer si alguna carrera existe. */
        public bool ExisteCarrera(Carrera arg0)
        {
            bool existe = false;

            //DataManager dm = DataManager.Instance;
            DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);
            foreach (Carrera c in dm.ObtenerCarrerasEnApp())
            {
 //               if (Carrera.MismaCarrera(arg0, c)) //TODO
                {
                    existe = true;
                }
            }

            return existe;
        }

        /* Nicolas Fernandez, 17/05/2017, metodo para comprobar si el plan de estudio existe. */
        public bool ExistePlanDeEstudio(PlanDeEstudio PlanEstudio)
        {
            bool existe = false;

            //DataManager dm = DataManager.Instance;
            DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);
            foreach (PlanDeEstudio pe in dm.ObtenerPlanesdeEstudioEnApp())
            {
                if (PlanEstudio.Equals(pe))
                {
                    existe = true;
                }
            }

            return existe;
        }

        /* Nicolas Fernandez, 17/05/2017, Genera el plan en el sistema. */
        public bool CrearPlanEstudio(Carrera Carrera, PlanDeEstudio PlanEstudio)
        {
            bool planCorrecto = false;
            //DataManager dm = DataManager.Instance;
            DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);

            CarreraBLL cbl = new CarreraBLL();

            /* Verifica si la carrera exite, en caso de no exister la crea. */
            if (!cbl.ExisteCarrera(Carrera))
            {
                cbl.RegistrarCarrera(Carrera);
            }

            /* Compara si el plan ya se encuentra en el sistema. */
            if (ExistePlanDeEstudio(PlanEstudio))
            {
                /* En caso de encontrarse, verifica si los planes contienen las mismas materias. */
            }
            else
            {
                /* En caso de no encontrarse crea el plan de estudio. */
            }

            return planCorrecto;
        }

    }
}