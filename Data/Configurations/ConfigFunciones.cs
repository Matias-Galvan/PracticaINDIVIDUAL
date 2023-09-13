using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ConfigFunciones
    {
        public ConfigFunciones(EntityTypeBuilder<Funcion> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(f => f.Pelicula).WithMany(p => p.Funciones).HasForeignKey(f => f.PeliculaId);
            entityTypeBuilder.Property(g => g.FuncionId).HasDefaultValue
            
        }
    }
}