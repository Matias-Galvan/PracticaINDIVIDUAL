using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infraestructure.Configurations
{
    public class ConfigTickets
    {
        public ConfigTickets(EntityTypeBuilder<Ticket> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(t => t.Funcion).WithMany(f => f.Tickets).HasForeignKey(t => t.FuncionId);
        }
    }
}
