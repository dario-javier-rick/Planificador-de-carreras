﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelContainer : DbContext
    {
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Usuario> UsuarioSet { get; set; }
        public virtual DbSet<Materia> MateriaSet { get; set; }
        public virtual DbSet<Carrera> CarreraSet { get; set; }
        public virtual DbSet<MateriasPorCarrera> MateriasPorCarreraSet { get; set; }
        public virtual DbSet<CarrerasPorUsuario> CarrerasPorUsuarioSet { get; set; }
        public virtual DbSet<MateriasPorUsuario> MateriasPorUsuarioSet { get; set; }
        public virtual DbSet<CorrelativaPorMateria> CorrelativaPorMateriaSet { get; set; }
    }
}
