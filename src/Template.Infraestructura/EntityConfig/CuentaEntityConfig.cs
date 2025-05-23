using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Infraestructura.EntityConfig
{
   public class CuentaEntityConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cliente).WithMany(x=> x.Cuentas).HasForeignKey(x => x.ClienteId);
            builder.Property(c => c.Saldo).HasPrecision(18, 2);
            
            builder.HasData(
                new Cuenta { Id = 101, ClienteId = 1, Saldo = 157500.25m, EsCuentaPrincipal = true },
                new Cuenta { Id = 102, ClienteId = 1, Saldo = 25300.75m, EsCuentaPrincipal = false },
                new Cuenta { Id = 103, ClienteId = 2, Saldo = 80200.00m, EsCuentaPrincipal = true },
                new Cuenta { Id = 104, ClienteId = 3, Saldo = 80200.00m, EsCuentaPrincipal = false }
            );
        }
    }
}
