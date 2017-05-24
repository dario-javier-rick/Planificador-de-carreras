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

        public static Carrera GenerateFromDataLine(string dataLine)
        {
            string[] datos = dataLine.Split(',');
            Carrera c = new Carrera {CodigoCarrera = int.Parse(datos[1]), Nombre = datos[2]};

            return c;
        }

        /* Nicolás Fernandez, 22/05/2017, Se crea una materia con codigo 0 ya que no esta registrada en la aplicacion
         * se le asigna codigo una vez registrada. */
        public static Carrera CrearCarrera(string nombre)
        {
            Carrera c = new Carrera { CodigoCarrera = 0,
                                        Nombre = nombre};

            return c;
        }

        /* Nicolas Fernandez, 22/05/2017, Compara dos materias por el nombre. */
        public static bool Mismas(Carrera carrera1, Carrera carrera2)
        {
            if (carrera1.Nombre.Trim().ToUpper().Equals(carrera2.Nombre.Trim().ToUpper()))
            {
                return true;
            }
            return false;
        }

        public static bool MismodId(Carrera carre, int codigoCarrera)
        {
            if (carre.CodigoCarrera == codigoCarrera)
            {
                return true;
            }
            return false;
        }
    }
}