﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;
using Planificador.BLL.Entidades;

namespace Planificador.BLL
{
    /// <summary>
    /// Patron Facade. Proveo una interfaz única para manejar la lógica de  subsistemas diferentes
    /// </summary>
    public class FacadeCursada
    {
        private CarreraBLL _carrera = new CarreraBLL();
        private MateriaBLL _materia = new MateriaBLL();
        private AlumnoBLL _alumno = new AlumnoBLL();
        public CaminoCritico CaminoCritico { get; } = new CaminoCritico();

        public FacadeCursada()
        {
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
            CaminoCritico.CalcularPesoEnCaminoCritico(materias);
            return CaminoCritico.DiccionarioCriticidad;
        }
    }
}