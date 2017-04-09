using System.Collections.Generic;
using Planificador.Models;

namespace Planificador.Logic
{
    public static class MateriasPorCarrera
    {
	
		public static IEnumerable<Materia> ListarMateriasLicenciaturaInformatica()
		{
			List<Materia> listaMaterias = new List<Materia>();

			Materia IP = new Materia{ 
				IdMateria = 1,
				Nombre = "Introduccion a la Programacion"
			};
			listaMaterias.Add(IP); 

			Materia P1 = new Materia
			{
				IdMateria = 2,
				Nombre = "Programacion 1",
				EsCorrealativaCon = new List<Materia> { IP }
			};
			listaMaterias.Add(P1);

			Materia P2 = new Materia
			{
				IdMateria = 3,
				Nombre = "Programacion 2",
				EsCorrealativaCon = new List<Materia> { P1 }
			};
			listaMaterias.Add(P2);

			Materia P3 = new Materia
			{
				IdMateria = 4,
				Nombre = "Programacion 3",
				EsCorrealativaCon = new List<Materia> { P2 }
			};
			listaMaterias.Add(P3);

			Materia IM = new Materia
			{
				IdMateria = 5,
				Nombre = "Introduccion a la Matematica",
			};
			listaMaterias.Add(IM);


			Materia LG = new Materia
			{
				IdMateria = 6,
				Nombre = "Logica y teoria de numeros",
				EsCorrealativaCon = new List<Materia> { IM }
			};
			listaMaterias.Add(LG);


			Materia MD = new Materia
			{
				IdMateria = 7,
				Nombre = "Matematica Discreta",
				EsCorrealativaCon = new List<Materia> { LG }
			};
			listaMaterias.Add(MD);

			return listaMaterias;

		}

    }
}