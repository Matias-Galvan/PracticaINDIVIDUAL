using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ConfigSalas
    {
        public ConfigSalas(EntityTypeBuilder<Sala> entityTypeBuilder) {
            entityTypeBuilder.HasKey(s => s.SalaId);
            entityTypeBuilder.HasMany(x => x.Funciones).WithOne(g => g.Sala).HasForeignKey(d => d.FuncionId);           

        }

    }
}
