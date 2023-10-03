using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class ConfigPeliculas
    {
        public ConfigPeliculas(EntityTypeBuilder<Pelicula> entityTypeBuilder)
        {
           entityTypeBuilder.HasKey(x => x.PeliculaId);
           entityTypeBuilder.Property(x => x.PeliculaId).ValueGeneratedOnAdd();
           entityTypeBuilder.Property(x => x.Titulo).IsRequired().HasMaxLength(50);
           entityTypeBuilder.Property(x => x.Sinopsis).IsRequired().HasMaxLength(255);
           entityTypeBuilder.Property(x => x.Poster).IsRequired().HasMaxLength(100);
           entityTypeBuilder.Property(x => x.Trailer).IsRequired().HasMaxLength(100);
           entityTypeBuilder.HasOne(x => x.Generos).WithMany(x => x.Peliculas).HasForeignKey(x => x.Genero);

        }
    }
}
