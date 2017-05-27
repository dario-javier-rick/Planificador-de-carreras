using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class CarreraBLL : IDataReader<Carrera>
    {
		DataManager dm = DataManager.Instance(Constantes.Constantes.DataManagerPath);

		public string ToDataLine(Carrera carrera)
        {
            return "[Carrera]," + carrera.CodigoCarrera + "," + carrera.Nombre;
        }

        public Carrera GenerateFromDataLine(string dataLine)
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


		internal bool ExisteCarrera(Carrera carrera)
		{
            return dm.ObtenerCarrerasEnApp().Exists(x => x.Nombre.Equals(carrera.Nombre));
		}

		/* Nicolás Fernández, 18/05/2017, Adignacion de código a carrera. */
		public int AsignarCodCarrera()
		{
            return dm.ObtenerCarrerasEnApp().Count + 1;
		}



		/* Nicolás Fernández, 18/05/2017, Metodo para saber si la carrera exite. */
		public int CodigoDeCarrera(Carrera carrera)
		{
			if (dm.ObtenerCarrerasEnApp().Exists(x => x.Nombre.Equals(carrera.Nombre)))
			{
				return dm.ObtenerCarrerasEnApp().Find(x => x.Nombre.Equals(carrera.Nombre)).CodigoCarrera;
			}
			return 0;
		}


		/* Nicolas Fernandez, 19/05/2017, Agregar Carrera */

		public void RegistrarCarrera(Carrera carrera)
		{
			if (carrera.CodigoCarrera == 0)
			{

				//string dataCarrera = "[Carrera],";
				//int cod = AsignarCodCarrera();
				//carreras.Add(new Carrera{CodigoCarrera = cod, Nombre = carrera.Nombre});
				//dataCarrera += cod + "," + carrera.Nombre;
				//System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\Planificador\Data\NewData.txt", true);
				//file.WriteLine(dataCarrera);
				//System.IO.StreamWriter file = new System.IO.StreamWriter(this.path);
				//file.Close();

				bool registrada = false;

				foreach (Carrera c in dm.ObtenerCarrerasEnApp())
				{
					if (CarreraBLL.Mismas(c, carrera))
						registrada = true;
				}

				if (!registrada)
				{
					carrera.CodigoCarrera = AsignarCodCarrera();
					dm.ObtenerCarrerasEnApp().Add(carrera);
					//System.IO.StreamWriter file = new System.IO.StreamWriter(this.path, true);
					//file.WriteLine("");
					//file.WriteLine(CarreraBLL.ToDataLine(carrera));

					//file.Close();
				}

			}

			//else

			//{

			//carreras.Add(carrera);

			//}

		}


		/* Nicolas Fernandez, 2/05/2017, Obtiene una carrera en particular. */
		public Carrera ObtenerCarrera(Carrera carrera)
		{
            foreach (Carrera c in dm.ObtenerCarrerasEnApp())
			{
				if (CarreraBLL.Mismas(carrera, c))
					return c;
			}
			return null;
		}

	}
}