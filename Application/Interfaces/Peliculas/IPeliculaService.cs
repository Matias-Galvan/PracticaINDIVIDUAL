﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaService
    {
        void CrearPelicula(Pelicula pelicula);
        List<Pelicula> GetAllPelicula();
        Pelicula GetPelicula(int id);

    }
}