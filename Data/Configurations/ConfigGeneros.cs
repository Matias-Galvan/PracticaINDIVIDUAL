using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configurations
{
    public class ConfigGeneros
    {
        public ConfigGeneros(EntityTypeBuilder<Genero> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(g => g.Peliculas).WithOne(p => p.Genero).HasForeignKey(p => p.GeneroId);
        }
    }
}
