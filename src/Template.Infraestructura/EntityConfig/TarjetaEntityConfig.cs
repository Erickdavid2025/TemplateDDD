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
    public class TarjetaEntityConfig : IEntityTypeConfiguration<Tarjeta>
    {
        public void Configure(EntityTypeBuilder<Tarjeta> builder)
        {

            builder.HasKey(X => X.Id);
            builder.HasOne(x => x.Cuenta).WithMany(x => x.Tarjetas).HasForeignKey(x => x.CuentaId);
           
            builder.HasData(
            new Tarjeta { Id = 1001 , CuentaId = 101 , Numero= "4509-8701-2345-6789", EsPrincipal =true },
            new Tarjeta { Id = 1002, CuentaId = 101, Numero = "4509-8701-2345-6789", EsPrincipal = false },
            new Tarjeta { Id = 2001, CuentaId = 103, Numero = "4510-2301-3345-1244", EsPrincipal = true }
            );

        }
    }
}
