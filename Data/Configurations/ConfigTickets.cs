using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ConfigTickets
    {
        public ConfigTickets(EntityTypeBuilder<Ticket> entityTypeBuilder) {
            entityTypeBuilder.HasOne(t => t.Funcion).WithMany(f => f.Tickets).HasForeignKey(t => t.FuncionId);
        }
    }
}
