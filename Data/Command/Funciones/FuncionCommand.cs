using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infraestructure.Command.Funciones
{
    public class FuncionCommand
    {
        private readonly CineContext _context;
        public FuncionCommand(CineContext context)
        {
            _context = context;
        }
    }
}
