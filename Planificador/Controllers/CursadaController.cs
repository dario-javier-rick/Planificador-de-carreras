using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planificador.Controllers
{
    public class CursadaController : Controller
    {
        public ActionResult Index()
        {
			List<Models.Materia> lista = new List<Models.Materia>();
			Models.Materia m = new Models.Materia();

			m.IdMateria = 1;
			m.Nombre = "Proyecto profesional 2";

			lista.Add(m);

            return View (lista);
        }
    }
}
