using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.BLL.Entidades
{
    public class MateriaBLL : IDataReader<Materia>
    {
        private static MateriaBLL _instancia;
        public List<Materia> ListaObj { get; }

        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <returns></returns>
        public static MateriaBLL Instance()
        {
            return _instancia ?? (_instancia = new MateriaBLL());
        }

        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        private MateriaBLL()
        {
            ListaObj = new List<Materia>();
        }

        public string ToDataLine(Materia materia)
		{
            return "[Materia]," + materia.Id;
		}

		public Materia GenerateFromDataLine(string dataLine)
		{
			string[] datos = dataLine.Split(',');
            Materia m = new Materia { Id = int.Parse(datos[1]) };

			return m;
		}

        //Otros metodos
        public static Materia CrearMateria(string nombre)
        {
            return new Materia { Nombre=nombre};
        }

        public static bool Misma(Materia ma, Materia materia)
        {
            if (ma.Nombre.Equals(materia.Nombre))
            {
                return true;
            }
            return false;
        }



        /* Nicolás Fernández, 17/05/2017, Retorna el resultado de la busqueda una materia. */
        public bool ExisteMateria(string NombreMateria)
        {
            bool existe = false;

            foreach (Materia mt in ListaObj)
            {
                if (mt.Nombre.Equals(NombreMateria))
                {
                    existe = true;
                }
            }
            return existe;
        }



        /* Nicolás Fernández, 17/05/2017, Devuelve una materia particular */
        public Materia ObtenerMateria(string nombreMateria)
        {
            foreach (Materia mt in ListaObj)
            {
                if (mt.Nombre.Equals(nombreMateria))
                    return mt;
            }
            return new Materia();
        }

    }
}