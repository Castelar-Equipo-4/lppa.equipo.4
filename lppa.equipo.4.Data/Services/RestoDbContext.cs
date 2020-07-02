using lppa.equipo._4.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lppa.equipo._4.Data.Services
{

    //DbContext generalmente representa una conexión de base de datos y un conjunto de tablas. 
    public partial class RestoDbContext : DbContext
    {
        public RestoDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<RestoDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Artist> Artist { get; set; }

        public virtual DbSet<Obras> Obra { get; set; }

        public virtual DbSet<Error> Error { get; set; }

        public virtual DbSet<Order> Carrito { get; set; }

    }
}
