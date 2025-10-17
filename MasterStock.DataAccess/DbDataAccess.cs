using MasterStock.Entitis;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.DataAccess
{
    public class DbDataAccess : IdentityDbContext
    {
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Proveedores> Proveedores{ get; set; }
        public virtual DbSet<MovimientosdeStock> MovimientosdeStocks { get; set; }
        public virtual DbSet<TipodeMovimientos> TipodeMovimientos { get; set; }
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
    }
}
