//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planificador.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MateriaAprobada
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public System.DateTime FechaAprobacion { get; set; }
        public int LibretaId { get; set; }
    
        public virtual Materia Materia { get; set; }
        public virtual Libreta Libreta { get; set; }
    }
}
