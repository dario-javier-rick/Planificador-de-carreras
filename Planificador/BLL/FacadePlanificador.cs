using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
using Planificador.BLL.Entidades;
using Planificador.BLL.Factory;

namespace Planificador.BLL
{
    /// <summary>
    /// Patron Facade. Proveo una interfaz única para manejar la lógica de varios subsistemas diferentes
    /// </summary>
    public class FacadePlanificador
    {
        private readonly AlumnoBLL _alumno;
        private readonly CarreraBLL _carrera;
        private readonly CorrelativaBLL _correlativas;
        private readonly CursadaBLL _cursada;
        private readonly DocenteBLL _docente;
        private readonly LibretaBLL _libreta;
        private readonly MateriaBLL _materia;
        private readonly PlanDeEstudioBLL _planDeEstudio;

        private readonly CaminoCritico _caminoCritico = new CaminoCritico();

        public FacadePlanificador()
        {
            BLLFactory bllFactory = new FactoryEntidades();

            _alumno = bllFactory.CrearAlumnoBLL();
            _carrera = bllFactory.CrearCarreraBLL();
            _correlativas = bllFactory.CrearCorrelativaBLL();
            _cursada = bllFactory.CrearCursadaBLL();
            _docente = bllFactory.CrearDocenteBLL();
            _libreta = bllFactory.CrearLibretaBLL();
            _materia = bllFactory.CrearMateriaBLL();
            _planDeEstudio = bllFactory.CrearPlanDeEstudioBLL();
        }

        public string EscribirObjeto<T>(T objeto) where T : class
        {
            switch (typeof(T).Name)
            {
                case nameof(Alumno):
                    return _alumno.ToDataLine((Alumno) Convert.ChangeType(objeto, typeof(T)));
                case nameof(Carrera):
                    return _carrera.ToDataLine((Carrera)Convert.ChangeType(objeto, typeof(T)));
                case nameof(Correlativa):
                    return _correlativas.ToDataLine((Correlativa)Convert.ChangeType(objeto, typeof(T)));
                case nameof(Cursada):
                    return _cursada.ToDataLine((Cursada)Convert.ChangeType(objeto, typeof(T)));
                case nameof(Docente):
                    return _docente.ToDataLine((Docente)Convert.ChangeType(objeto, typeof(T)));
                case nameof(Libreta):
                    return _libreta.ToDataLine((Libreta)Convert.ChangeType(objeto, typeof(T)));
                case nameof(Materia):
                    return _materia.ToDataLine((Materia)Convert.ChangeType(objeto, typeof(T)));
                case nameof(PlanDeEstudio):
                    return _planDeEstudio.ToDataLine((PlanDeEstudio)Convert.ChangeType(objeto, typeof(T)));
                default:
                    throw new Exception("Tipo no soportado");
            }
        }

        public T GenerarObjeto<T>(string s) where T : class
        {
            switch (typeof(T).Name)
            {
                case nameof(Alumno):
                    return (T)Convert.ChangeType(_alumno.GenerateFromDataLine(s), typeof(T));
                case nameof(Carrera):
                    return (T)Convert.ChangeType(_carrera.GenerateFromDataLine(s), typeof(T));
                case nameof(Correlativa):
                    return (T)Convert.ChangeType(_correlativas.GenerateFromDataLine(s), typeof(T));
                case nameof(Cursada):
                    return (T)Convert.ChangeType(_cursada.GenerateFromDataLine(s), typeof(T));
                case nameof(Docente):
                    return (T)Convert.ChangeType(_docente.GenerateFromDataLine(s), typeof(T));
                case nameof(Libreta):
                    return (T)Convert.ChangeType(_libreta.GenerateFromDataLine(s), typeof(T));
                case nameof(Materia):
                    return (T) Convert.ChangeType(_materia.GenerateFromDataLine(s), typeof(T));
                case nameof(PlanDeEstudio):
                    return (T)Convert.ChangeType(_planDeEstudio.GenerateFromDataLine(s), typeof(T));
                default:
                    throw new Exception("Tipo no soportado");
            }
        }


        //Getters de listas
        public List<Alumno> ObtenerAlumnos()
        {
            return _alumno.ListaObj;
        }

        public List<Carrera> ObtenerCarreras()
        {
            return _carrera.ListaObj;
        }

        public List<Correlativa> ObtenerCorrelativas()
        {
            return _correlativas.ListaObj;
        }

        public List<Cursada> ObtenerCursadas()
        {
            return _cursada.ListaObj;
        }

        public List<Docente> ObtenerDocentes()
        {
            return _docente.ListaObj;
        }

        public List<Libreta> ObtenerLibretas()
        {
            return _libreta.ListaObj;
        }

        public List<Materia> ObtenerMaterias()
        {
            return _materia.ListaObj;
        }

        public List<PlanDeEstudio> ObtenerPlanesDeEstudio()
        {
            return _planDeEstudio.ListaObj;
        }


        //Otros métodos
        internal void RegistrarCarrera(Carrera carrera)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Dado un alumno, devuelve las materias que puede cursar teniendo en cuenta las de los planes de estudios, las ya cursadas, las que le faltan y las correlativas.
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static IEnumerable<Materia> ObtenerPosiblesMateriasACursar(Alumno alumno)
        {
            if (alumno == null)
            {
                return Enumerable.Empty<Materia>();
            }

            //TODO: Patron observer? Nico V: noup, observer es para el front

            //Recorro todos los planes de estudios del alumno, y obtengo las materias correspondientes
            List<PlanDeEstudio> planesDeEstudios = alumno.PlanDeEstudio.ToList();
            HashSet<Materia> materiasDeCarreras = new HashSet<Materia>();

            foreach (PlanDeEstudio plan in planesDeEstudios)
            {
                foreach (Materia materia in plan.Materia)
                {
                    materiasDeCarreras.Add(materia);
                }
            }

            //Me fijo que materias aprobadas tiene el alumno
            IEnumerable<Materia> materiasAprobadas = AlumnoBLL.ListarMateriasAprobadas(alumno);

            //Devuelvo las que realmente pueden ser cursadas.
            return AlumnoBLL.ObtenerMateriasQuePuedoCursar(materiasAprobadas, materiasDeCarreras);
        }

        public Dictionary<Materia, int> CalcularPesoEnCaminoCritico(List<Materia> materias)
        {
            _caminoCritico.CalcularPesoEnCaminoCritico(materias);
            return _caminoCritico.DiccionarioCriticidad;
        }

        public bool ExisteCarrera(Carrera carrera)
        {
            throw new NotImplementedException();
        }

        public Carrera ObtenerCarrera(Carrera carrera)
        {
            return _carrera.ListaObj.FirstOrDefault(c => c.CodigoCarrera == carrera.CodigoCarrera);
        }

        public PlanDeEstudio ObtenerPlanesEstudio(PlanDeEstudio pe)
        {
            throw new NotImplementedException();
        }
    }
}