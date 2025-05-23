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
    public class MovimientoEntityConfig : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.HasKey(X => X.Id);
            builder.HasOne(x => x.Tarjeta).WithMany(x => x.Movimiento).HasForeignKey(x => x.TarjetaId);

            builder.HasData(
                new Movimiento { Id = 1, TarjetaId = 1001, Fecha = new DateTime (2024,04,20), Monto = -9500.00m,  Descripcion= "Compra supermercado" },
                new Movimiento { Id = 2, TarjetaId = 1001, Fecha = new DateTime (2024,04,18), Monto = -12000.00m, Descripcion = "Pago seguro auto" },
                new Movimiento { Id = 3, TarjetaId = 1001, Fecha = new DateTime (2024,04,15), Monto = -6500.00m,  Descripcion = "Farmacia" },
                new Movimiento { Id = 4, TarjetaId = 1001, Fecha = new DateTime (2024,04,12), Monto = -43000.00m, Descripcion = "Electrodoméstico" },
                new Movimiento { Id = 5, TarjetaId = 1001, Fecha = new DateTime (2024,04,10), Monto = -1999.00m,  Descripcion = "Spotify Premium" },
                new Movimiento { Id = 6, TarjetaId = 1001, Fecha = new DateTime (2024,03,28), Monto = -1500.00m,  Descripcion = "Carga SUBE" },
                new Movimiento { Id = 7, TarjetaId = 1002, Fecha = new DateTime(2024,04, 05), Monto = -3000.00m,  Descripcion = "Compra secundaria" },
                new Movimiento { Id = 8, TarjetaId = 2001, Fecha = new DateTime(2024,04, 19), Monto = -7500.00m,  Descripcion = "Cena en restaurante" },
                new Movimiento { Id = 9, TarjetaId = 2001, Fecha = new DateTime(2024,04, 17), Monto = -3000.00m,  Descripcion = "Pago Netflix" },
                new Movimiento { Id = 10,TarjetaId = 2001, Fecha = new DateTime(2024,04, 14), Monto = -18000.00m, Descripcion = "Compra electro" },
                new Movimiento { Id = 11, TarjetaId = 2001, Fecha = new DateTime(2024, 04, 14), Monto = -18000.00m, Descripcion = "Compra Carro" }
             );
        }
    }
}
