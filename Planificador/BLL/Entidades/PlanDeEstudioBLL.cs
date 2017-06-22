using System;
using System.Collections.Generic;
using System.Linq;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class PlanDeEstudioBLL: IDataReader<PlanDeEstudio>
    {
        private static PlanDeEstudioBLL _instancia;
        public List<PlanDeEstudio> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static PlanDeEstudioBLL Instance()
        {
            return _instancia ?? (_instancia = new PlanDeEstudioBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private PlanDeEstudioBLL()
        {
            ListaObj = new List<PlanDeEstudio>();
        }

        public string ToDataLine(PlanDeEstudio plan)
		{
            return "[PlanDeEstudio]," + plan.Id;
		}

        public PlanDeEstudio GenerateFromDataLine(string fromDataLine)
		{
			string[] planArray = fromDataLine.Split(',');
		    CarreraBLL c = CarreraBLL.Instance();
            PlanDeEstudio plan = new PlanDeEstudio
			{
                Id = Convert.ToInt32(planArray[1]),
                Carrera = c.ObtenerCarrera(Convert.ToInt32(planArray[2]))
			};
            return plan;
		}

        /* Nicolas Fernandez, 23/05/2017, Etiqueta de identificacion. */
        public static bool DataLineToMe(string dataline)
        {
            string[] data = dataline.Split(',');
//            if (data[0].Equals(carreraPlan))
//                return true;
            return false; 
        }

        /* Nicolas Fernandez, 23/05/2017. Crea plan de estudio */
        public static PlanDeEstudio CrearPlan(Carrera carrera, int codigo)
        {
            /* Se crea el plan de estudio. */
            PlanDeEstudio pe = new PlanDeEstudio { Carrera = carrera,
                CodigoCarrera = carrera.CodigoCarrera,
                Id = codigo };

            /* Se asigna el plan de estudio a la carrera. */
            carrera.PlanDeEstudios.Add(pe);

            return pe;
        }

        public static bool Mismos(PlanDeEstudio plan1, PlanDeEstudio plan2)
        {
            if (plan1.Id == plan2.Id
                && CarreraBLL.Mismas(plan1.Carrera, plan2.Carrera))
            {
                return true;
            }
            return false;
        }

        /* Nicolas Fernande, 27/05/2017, Genera plan a partir de lectura de datos de un string. */
        public static PlanDeEstudio GerateFromDataLine(string line)
        {
            string[] data = line.Split(',');
            PlanDeEstudio pe = null;

            if (/*data[0].Equals(carreraPlan)*/true)
            {
                pe = new PlanDeEstudio
                {
                    CodigoCarrera = int.Parse(data[1]),
                    Id = int.Parse(data[2])
                };
      /*          foreach (Carrera carre in dm.ObtenerCarrerasEnApp())
                {
                    if (CarreraBLL.MismodId(carre, pe.CodigoCarrera))
                    {
                        pe.Carrera = carre;
                    }
                }
        */    }

            return pe;
        }

        public static List<Materia> ObtenerMateriasQueNoRequierenCorrelativas(List<Materia> materiasNoCursadas, IEnumerable<Materia> materiasAprobadas)
        {
            List<Materia> materiasQueNoRequierenCorrelativas = new List<Materia>();
            foreach (Materia materia in materiasNoCursadas)
            {
                if (materia.Correlativas.Any())
                {
                    //Valido si aprobe las correlativas
                    List<Materia> correlativas = null;//materia.Correlativas.ToList(); //TODO


                    int indice = 0;
                    bool ingresaMateria = true;

                    while (ingresaMateria == true && indice < correlativas.Count)
                    {
                        if (!materiasAprobadas.Contains(correlativas[indice]))
                        {
                            ingresaMateria = false;
                        }

                        indice++;
                    }

                    if (ingresaMateria)
                    {
                        materiasQueNoRequierenCorrelativas.Add(materia);
                    }

                }
                else
                {
                    materiasQueNoRequierenCorrelativas.Add(materia);
                }
            }

            return materiasQueNoRequierenCorrelativas;
        }


		/* Nicolas Fernandez, 23/05/2017, Obtiene plan de esudio especifico. */
		public PlanDeEstudio ObtenerPlanesEstudio(PlanDeEstudio plan)
		{
            foreach (PlanDeEstudio pe in ListaObj)
			{
				if (PlanDeEstudioBLL.Mismos(plan, pe))
				{
					return pe;
				}
			}
			return null;
		}


		public void CrearUnNuevoPlanDeEstudio(PlanDeEstudio Plan)
		{
            ListaObj.Add(Plan);
		}

    }
}