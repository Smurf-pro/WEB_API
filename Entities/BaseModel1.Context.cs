//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Api.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Inventarizacia_ob_VUZaEntities : DbContext
    {
        public Inventarizacia_ob_VUZaEntities()
            : base("name=Inventarizacia_ob_VUZaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Akusticheskaya_system> Akusticheskaya_system { get; set; }
        public virtual DbSet<Auditoriya> Auditoriya { get; set; }
        public virtual DbSet<Computers> Computers { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<History_Akusticheskaya_system> History_Akusticheskaya_system { get; set; }
        public virtual DbSet<History_Computers> History_Computers { get; set; }
        public virtual DbSet<History_Klaviatura> History_Klaviatura { get; set; }
        public virtual DbSet<History_Monitor> History_Monitor { get; set; }
        public virtual DbSet<History_Mouse> History_Mouse { get; set; }
        public virtual DbSet<History_Printer> History_Printer { get; set; }
        public virtual DbSet<History_Proector> History_Proector { get; set; }
        public virtual DbSet<History_Scaner> History_Scaner { get; set; }
        public virtual DbSet<History_Sklad> History_Sklad { get; set; }
        public virtual DbSet<Klaviatura> Klaviatura { get; set; }
        public virtual DbSet<Monitor> Monitor { get; set; }
        public virtual DbSet<Mouse> Mouse { get; set; }
        public virtual DbSet<Printer> Printer { get; set; }
        public virtual DbSet<Proector> Proector { get; set; }
        public virtual DbSet<Scaner> Scaner { get; set; }
        public virtual DbSet<Sklad> Sklad { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
