using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planificador.BLL.DTO;

namespace Planificador.BLL.Handler
{
    public abstract class HandlerBase
    {
        protected HandlerBase Sucesor;

        public void ConfigurarSucesor(HandlerBase sucesor)
        {
            this.Sucesor = sucesor;
        }

        public abstract void ProcesarPedido(PlanificadorCaminoMinimoDTO planificador);
    }
}