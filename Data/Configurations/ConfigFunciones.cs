using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class ConfigFunciones
    {
        public ConfigFunciones(EntityTypeBuilder<Funcion> entityTypeBuilder)
        {
            entityTypeBuilder.Property(j => j.FuncionId).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(f => f.Pelicula).WithMany(p => p.Funciones).HasForeignKey(f => f.PeliculaId);

        }
    }
}