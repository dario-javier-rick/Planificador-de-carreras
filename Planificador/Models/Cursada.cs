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
    
    public partial class Cursada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursada()
        {
            this.Alumno = new HashSet<BLL.Entidades.AlumnoBLL>();
            this.Materia = new HashSet<Materia>();
        }
    
        public string Comision { get; set; }
        public string Semestre { get; set; }
        public string Horarios { get; set; }
        public int ProfesorId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BLL.Entidades.AlumnoBLL> Alumno { get; set; }
        public virtual Profesor Profesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materia> Materia { get; set; }
    }
}