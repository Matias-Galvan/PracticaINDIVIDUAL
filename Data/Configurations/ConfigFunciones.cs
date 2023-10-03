using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class ConfigFunciones
    {
        public ConfigFunciones(EntityTypeBuilder<Funcion> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.FuncionId);
            entityTypeBuilder.Property(x => x.FuncionId).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(x => x.Fecha).IsRequired();
            entityTypeBuilder.Property(x => x.Horario).IsRequired();
            entityTypeBuilder.HasOne(x => x.Salas).WithMany(x => x.Funciones).HasForeignKey(x => x.SalaId);
            entityTypeBuilder.HasOne(x => x.Peliculas).WithMany(x => x.Funciones).HasForeignKey(x => x.PeliculaId);
        }
    }
}