using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Infraestructura.EntityConfig;

namespace Template.Infraestructura.ORM
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public MyDbContext()
        {
            
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ClienteEntityConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        }

     }
}
