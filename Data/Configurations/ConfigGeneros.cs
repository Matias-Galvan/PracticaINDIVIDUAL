using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class ConfigGeneros
    {
        public ConfigGeneros(EntityTypeBuilder<Genero> entityTypeBuilder)
        {
           entityTypeBuilder.HasKey(x => x.GeneroId);
           entityTypeBuilder.Property(x => x.GeneroId).ValueGeneratedOnAdd();
           entityTypeBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}
