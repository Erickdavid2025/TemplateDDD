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
    public class ClienteEntityConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x =>  x.Id);
            builder.Property(x => x.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasData(
                new Cliente { Id = 1, Nombre = "Jose Ramon" },
                new Cliente { Id = 2, Nombre = "Hernan Perez" },
                new Cliente { Id = 3, Nombre = "Ramon Castro" },
                new Cliente { Id = 4, Nombre = "Alex Rodriguez" }
             );
        }

    }
}
