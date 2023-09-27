﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface IPeliculaCommand
    {
        Task<PeliculaDTOResponse> actualizarPelicula(int funcionId);
    }
}
