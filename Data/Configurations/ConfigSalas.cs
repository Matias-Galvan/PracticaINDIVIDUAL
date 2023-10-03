using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class ConfigSalas
    {
        public ConfigSalas(EntityTypeBuilder<Sala> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.SalaId);
            entityTypeBuilder.Property(x => x.SalaId).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        }

    }
}
