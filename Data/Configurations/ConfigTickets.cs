using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infraestructure.Configurations
{
    public class ConfigTickets
    {
        public ConfigTickets(EntityTypeBuilder<Ticket> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new {x.TicketId, x.FuncionId});
            entityTypeBuilder.Property(x => x.Usuario).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x => x.TicketId).ValueGeneratedOnAdd();
            entityTypeBuilder.HasOne(x => x.Funciones).WithMany(x => x.Tickets).HasForeignKey(x => x.FuncionId);
        }
    }
}
