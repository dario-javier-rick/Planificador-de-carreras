using System;
using System.Collections.Generic;
using System.Linq;
using Planificador.Models;


namespace Planificador.BLL

{

    public class DataManager
    {

        private readonly string _path;
        private bool _readed;

        public DataManager(string path)
        {
            _readed = false;
            _path = path;
        }


        /// <summary>
		/// Nicolás Fernández, 18/05/2017, Carga datos desde el archivo.
		/// </summary>
		public void CargarDatos()
        {
            FacadePlanificador fc = new FacadePlanificador();

            System.IO.StreamReader file = new System.IO.StreamReader(_path);
            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                string tipoRegistro = ValidarTipoRegistro(line);

                switch (tipoRegistro)
                {
                    case nameof(Correlativa):
                        List<Correlativa> corBll = fc.ObtenerCorrelativas();
                        corBll.Add(fc.GenerarObjeto<Correlativa>(line));
                        break;
                    case nameof(PlanDeEstudio):
                        List<PlanDeEstudio> plaBll = fc.ObtenerPlanesDeEstudio();
                        plaBll.Add(fc.GenerarObjeto<PlanDeEstudio>(line));
                        break;
                    case nameof(Alumno):
                        List<Alumno> aluBll = fc.ObtenerAlumnos();
                        aluBll.Add(fc.GenerarObjeto<Alumno>(line));
                        break;
                    case nameof(Carrera):
                        List<Carrera> carBll = fc.ObtenerCarreras();
                        carBll.Add(fc.GenerarObjeto<Carrera>(line));
                        break;
                    case nameof(Cursada):
                        List<Cursada> curBll = fc.ObtenerCursadas();
                        curBll.Add(fc.GenerarObjeto<Cursada>(line));
                        break;
                    case nameof(Materia):
                        List<Materia> matBll = fc.ObtenerMaterias();
                        matBll.Add(fc.GenerarObjeto<Materia>(line));
                        break;
                    case nameof(Docente):
                        List<Docente> docBll = fc.ObtenerDocentes();
                        docBll.Add(fc.GenerarObjeto<Docente>(line));
                        break;
                    case nameof(Libreta):
                        List<Libreta> libBll = fc.ObtenerLibretas();
                        libBll.Add(fc.GenerarObjeto<Libreta>(line));
                        break;
                    case "PlanDeEstudioMateria":
                        string[] array = line.Split(',');
                        PlanDeEstudio plan = fc.ObtenerPlanesDeEstudio().FirstOrDefault(p => p.Id == Convert.ToInt32(array[1]));
                        Materia materia = fc.ObtenerMaterias().FirstOrDefault(m => m.Id == Convert.ToInt32(array[2]));
                        plan.Materia.Add(materia);
                        materia.PlanDeEstudio.Add(plan);
                        break;
                    case "PlanDeEstudioAlumno":
                        string[] array2 = line.Split(',');
                        PlanDeEstudio plan2 = fc.ObtenerPlanesDeEstudio().FirstOrDefault(p => p.Id == Convert.ToInt32(array2[1]));
                        Alumno alumno = fc.ObtenerAlumnos().FirstOrDefault(a => a.Id == Convert.ToInt32(array2[2]));
                        plan2.Alumno.Add(alumno);
                        alumno.PlanDeEstudio.Add(plan2);
                        break;
                }

            }

            _readed = true;

            file.Close();
        }

        private static string ValidarTipoRegistro(string linea)
        {
            int posicion1 = linea.IndexOf('[');
            int posicion2 = linea.IndexOf(']');

            if (posicion1 != -1 && posicion2 != -1)
            {
                return linea.Substring(posicion1 + 1, posicion2 - 1);
            }

            return String.Empty;
        }

        public bool Leido()
        {
            return _readed;
        }

        public void GuardarDatos(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            FacadePlanificador fc = new FacadePlanificador();

            foreach (Alumno a in fc.ObtenerAlumnos())
            {
                file.WriteLine(fc.EscribirObjeto(a));
            }

            foreach (Carrera c in fc.ObtenerCarreras())
            {
                file.WriteLine(fc.EscribirObjeto(c));
            }

            file.Close();
        }

        public void EliminarDatos()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(_path);
            file.WriteLine("");
            file.Close();
        }


    }

}