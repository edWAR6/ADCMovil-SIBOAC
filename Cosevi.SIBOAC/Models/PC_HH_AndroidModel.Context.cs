﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cosevi.SIBOAC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PC_HH_AndroidEntities : DbContext
    {
        public PC_HH_AndroidEntities()
            : base("name=PC_HH_AndroidEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ESTCIVIL> ESTCIVILs { get; set; }
        public virtual DbSet<ILUMINACION> ILUMINACION { get; set; }
        public virtual DbSet<MANIOBRA> MANIOBRAs { get; set; }
        public virtual DbSet<MotivoPorNoFirmar> MotivoPorNoFirmars { get; set; }
        public virtual DbSet<Obstaculo> Obstaculo { get; set; }
        public virtual DbSet<OficinaParaImpugnar> OficinaParaImpugnars { get; set; }
        public virtual DbSet<RolDePersonaPorVehiculo> RolDePersonaPorVehiculoes { get; set; }
        public virtual DbSet<DISPOSITIVO> DISPOSITIVOes { get; set; }
    }
}
