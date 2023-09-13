﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IPeliculaService
    {
        void crearPelicula(Pelicula pelicula);
        List<Pelicula> getAllPelicula();
        Pelicula getPelicula(int id);

    }
}
