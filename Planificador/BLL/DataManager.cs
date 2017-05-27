using System;
using System.Collections.Generic;
using Planificador.BLL.Entidades;
using Planificador.Models;
using Planificador.BLL.Constantes;


namespace Planificador.BLL

{

    public class DataManager

    {
        private static DataManager instancia;
		private FacadeCursada fc = new FacadeCursada();

		private string path;
        private bool readed = false;

        private List<Alumno> alumnos = new List<Alumno>();
        private List<Carrera> carreras = new List<Carrera>();
        private List<Correlativa> correlativas = new List<Correlativa>();
        private List<Cursada> cursadas = new List<Cursada>();
        private List<Libreta> libretas = new List<Libreta>();
        private List<Materia> materias = new List<Materia>();
        private List<PlanDeEstudio> planes = new List<PlanDeEstudio>();
        private List<Profesor> profesores = new List<Profesor>();


        /// <summary>
        /// Patrón Singleton
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataManager Instance(string path)
        {
            if (instancia == null)
            {
                instancia = new DataManager(path);
            }
            return instancia;
        }



        /// <summary>
        /// Constructor privado. Patrón Singleton
        /// </summary>
        /// <param name="path"></param>
        private DataManager(string path)
        {
            path = path + @"\" + Constantes.Constantes.NombreArchivo;
            if (!readed)
            {
                CargarDatos();
				readed = true;
            }
        }


		/// <summary>
		/// Nicolás Fernández, 18/05/2017, Carga datos desde el archivo.
		/// </summary>
		public void CargarDatos()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                string tipoRegistro = ValidarTipoRegistro(line);

                switch(tipoRegistro)
                {
                    case nameof(Correlativa):
                        break;
                    case nameof(PlanDeEstudio):
                        break;
                    case nameof(Alumno):
                        alumnos.Add(fc._alumno.GenerateFromDataLine(line));
						break;
                    case nameof(Carrera):
                        carreras.Add(fc._carrera.GenerateFromDataLine(line));
						break;
                    case nameof(Cursada):
						break;
					case nameof(Materia):
                        materias.Add(fc._materia.GenerateFromDataLine(line));
						break;
                    case nameof(Profesor):
						break;
                    case nameof(Libreta):
						break;
                }




                if (PlanDeEstudioBLL.DataLineToMe(line))
                {
                    //PlanDeEstudio plan = PlanDeEstudioBLL.GerateFromDataLine(line);

                    //planes.Add(plan);

                    //foreach (Carrera carreraPlan in carreras)
                    //{
                        //tengo que agregar las materias
                        //agrego correlativas
                        //agrego alumno
                    //    if (plan.CodigoCarrera == carreraPlan.CodigoCarrera)
                    //    {
                    //        plan.Carrera = carreraPlan;
                    //        carreraPlan.PlanDeEstudios.Add(plan);
                    //    }
                    //}

                }
            }

			file.Close();
        }

        private string ValidarTipoRegistro(string linea)
        {
            int posicion1 = linea.IndexOf('[');
            int posicion2 = linea.IndexOf(']');

            return linea.Substring(posicion1, posicion2 - 1);
        }

        public void GuardarDatos(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            foreach (Alumno a in alumnos)
            {
                file.WriteLine(fc._alumno.ToDataLine(a));
            }

            foreach (Carrera c in carreras)
            {
                //file.WriteLine(CarreraBLL.ToDataLine(c));
            }

            file.Close();
        }



        public void EliminarDatos(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            file.WriteLine("");
            file.Close();
        }




		/** Obtencion de datos. **/

		public static List<T> ObtenerObjetos<T>(ref T obj) where T : class //ModelBase
		{
			List<T> dtoList = new List<T>();
			

            T dto = null;
			//dto = (T)parser.PopulateDTO(reader);
			dtoList.Add(dto);

            return dtoList;
        }

        public List<Carrera> ObtenerCarrerasEnApp()
        {
            return carreras;
        }
		public List<Alumno> ObtenerAlumnosEnApp()
		{
			return alumnos;
		}
		public List<PlanDeEstudio> ObtenerPlanesdeEstudioEnApp()
		{
			return planes;
		}
		public List<Materia> ObtenerMateriasEnApp()
		{
			return materias;
		}



    }

}