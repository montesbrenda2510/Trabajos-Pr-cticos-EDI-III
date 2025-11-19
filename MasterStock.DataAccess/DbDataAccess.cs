using MasterStock.DataAccess.MicrosoftIdentity;
using MasterStock.Entitis;
using MasterStock.Entitis.MicrosoftIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterStock.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid, UserClaim, UserRole , UserLogin, RoleClaim, UserToken>
    {
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Proveedor> Proveedores{ get; set; }
        public virtual DbSet<MovimientodeStock> MovimientosdeStocks { get; set; }
        public virtual DbSet<TipodeMovimiento> TipodeMovimientos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
    }
}
