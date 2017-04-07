using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.Models;

namespace Planificador.Logic
{
    public static class DbContext
    {
        public static IEnumerable<Materia> GetListaDeMaterias()
        {
            var lista = GetListaDeMateriasSinCorrelativas();
            lista.AddRange(GetListaDeMateriasConCorrelativas());
            return lista;
        }

        public static IEnumerable<Materia> GetListaDeMaterias(string nombre)
        {
            var lista = GetListaDeMateriasSinCorrelativas();
            lista.Add(new Materia
            {
                IdMateria = 7,
                Nombre = "Programacion I",
            });

            return lista;
        }

        private static List<Materia> GetListaDeMateriasSinCorrelativas()
        {
            return new List<Materia> {
                new Materia
                {
                    IdMateria = 1,
                    Nombre = "Introduccion a la Programacion"
                },
                new Materia
                {
                    IdMateria = 2,
                    Nombre = "Introduccion a la Matematica"
                },
                new Materia
                {
                    IdMateria = 3,
                    Nombre = "Orgranizacion del Computador I"
                },
                new Materia
                {
                    IdMateria = 4,
                    Nombre = "Problemas Socioeconomicos Contemporaneos"
                }
                ,new Materia
                {
                    IdMateria = 5,
                    Nombre = "Taller de Utilitarios"
                },
                new Materia
                {
                    IdMateria = 6,
                    Nombre = "Lectoescritura"
                }
            };
        }

        private static List<Materia> GetListaDeMateriasConCorrelativas()
        {
            return new List<Materia> {
                new Materia
                {
                    IdMateria = 7,
                    Nombre = "Programacion I"
                },
                new Materia
                {
                    IdMateria = 8,
                    Nombre = "Programacion II"
                },
                new Materia
                {
                    IdMateria = 9,
                    Nombre = "Programacion III"
                },
                new Materia
                {
                    IdMateria = 10,
                    Nombre = "Especificacion de Software"
                }
                ,new Materia
                {
                    IdMateria = 11,
                    Nombre = "Base de Datos I"
                },
                new Materia
                {
                    IdMateria = 12,
                    Nombre = "Base de Datos II"
                },
                new Materia
                {
                    IdMateria = 13,
                    Nombre = "Ingenieria de Software I"
                },
                new Materia
                {
                    IdMateria = 14,
                    Nombre = "Ingenieria de Software II"
                }
            };
        }
    }
}