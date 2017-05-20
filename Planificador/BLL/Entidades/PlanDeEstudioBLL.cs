using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class PlanDeEstudioBLL
    {

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

    }
}