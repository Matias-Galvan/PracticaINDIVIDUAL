﻿namespace Application.DTO
{
    public class FuncionDTOResponse
    {
        public int FuncionId { get; set; }
        public PeliculaDTOResponse Pelicula { get; set; }
        public SalaDTOResponse Sala { get; set; }
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
    }
    public class PeliculaDTOResponse
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public virtual GeneroDTOResponse Genero { get; set; }
    }
    public class SalaDTOResponse
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
    }
    public class GeneroDTOResponse
    {
        public int id { get; set; }
        public string Nombre { get; set; }
    }
}