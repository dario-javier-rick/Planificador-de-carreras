﻿using System;
using System.Collections.Generic;
using System.Linq;
using Planificador.Models;
using Planificador.BLL.Entidades;
using Planificador.BLL.Factory;
using Planificador.BLL.Helpers;

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
        private readonly ActaInscripcionBLL _actaIncipcion;
       
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
            this._actaIncipcion = bllFactory.CrearActaInscipcionBLL();
        }

        internal List<Carrera> ObtenerCarrerasDeAlumno(Alumno alumno)
        {
            List<Carrera> carreras = new List<Carrera>();

            List<PlanDeEstudio> planes = alumno.PlanDeEstudio.ToList();

            foreach (PlanDeEstudio plan in planes)
            {
                carreras.Add(plan.Carrera);
            }

            return carreras;
        }

        internal Carrera ObtenerCarreraPorId(int codigoCarrera)
        {
            return ObtenerCarreras().Find(x => x.CodigoCarrera == codigoCarrera);
        }

        internal Alumno ObtenerAlumnoPorId(int id)
        {
            return ObtenerAlumnos().Find(x => x.Id == id);
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
                case nameof(ActaInscripcion):
                    return (T)Convert.ChangeType(_actaIncipcion.GenerateFromDataLine(s), typeof(T));
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

        public List<ActaInscripcion> ObternerActasdeInscripcion()
        {
            return _actaIncipcion.ListaObj;
        }

        //Otros métodos

        public bool ExisteCarrera(Carrera carrera)
        {
            return _carrera.ExisteCarrera(carrera);
        }

        public Carrera ObtenerCarrera(Carrera carrera)
        {
            return _carrera.ListaObj.FirstOrDefault(c => c.CodigoCarrera == carrera.CodigoCarrera);
        }

        public PlanDeEstudio ObtenerPlanesEstudio(PlanDeEstudio pe)
        {
            return _planDeEstudio.ListaObj.FirstOrDefault(p => p.Id == pe.Id);
        }

        public PlanDeEstudio ObtenerPlanEstudioParaCarrera(Carrera carrera)
        {
            return this.ObtenerPlanesDeEstudio().Find(x => x.Carrera.CodigoCarrera == carrera.CodigoCarrera);
        }

        public List<Materia> ObtenerMateriasAprobadasPara(Alumno alumno)
        {
            //return AlumnoBLL.ListarMateriasAprobadas(alumno);
            var libreta = ObtenerLibretas().FirstOrDefault(x => x.Alumno.Id == alumno.Id);
            var mat = from mata in libreta.MateriaAprobada
                select mata.Materia;

            return mat.ToList();

        }
    }
}