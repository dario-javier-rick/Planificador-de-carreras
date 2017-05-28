using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Planificador.BLL;
using Planificador.BLL.Constantes;

namespace Planificador
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataManager dm = new DataManager(Constantes.DataManagerPath + @"bin\Debug\Data\" + Constantes.NombreArchivo);
            dm.CargarDatos();
        }
    }
}
