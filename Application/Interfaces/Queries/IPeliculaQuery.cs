using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IPeliculaQuery
    {
        Task<List<PeliculaDTOResponse>> GetPeliculas();
        Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId);
    }
}
