//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planificador.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarrerasPorUsuario
    {
        public int IdCarreraPorUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdCarrera { get; set; }
        public decimal Promedio { get; set; }
        public decimal PorcentajeCompletitud { get; set; }
    
        public virtual Alumno Usuario { get; set; }
        public virtual Carrera Carrera { get; set; }
    }
}
