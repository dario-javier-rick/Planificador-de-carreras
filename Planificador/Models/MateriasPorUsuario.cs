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
    
    public partial class MateriasPorUsuario
    {
        public int IdMateriaPorUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdMateria { get; set; }
        public bool EstaAprobada { get; set; }
        public short Nota { get; set; }
    
        public virtual Alumno Usuario { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
