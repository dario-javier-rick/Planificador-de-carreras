using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class CarreraBLL
    {
        public static string ToDataLine(Carrera carrera)
        {
            return "[Carrera]," + carrera.CodigoCarrera + "," + carrera.Nombre;
        }

        internal static Carrera GenerateFromDataLine(string line)
        {
            string[] datos = line.Split(',');

            Carrera c = new Carrera { CodigoCarrera = int.Parse(datos[1]),
                                        Nombre = datos[2]};

            return c;
        }

        public static Carrera CrearCarrera(string carrera)
        {
            DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);

            return null;
        }
    }
}