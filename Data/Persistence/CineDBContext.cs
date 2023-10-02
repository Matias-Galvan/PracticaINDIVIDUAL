using Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Persistence
{
    public class CineDBContext : DbContext
    {
        public CineDBContext()
        {

        }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Cine;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ConfigFunciones(modelBuilder.Entity<Funcion>());
            new ConfigGeneros(modelBuilder.Entity<Genero>());
            new ConfigSalas(modelBuilder.Entity<Sala>());
            new ConfigTickets(modelBuilder.Entity<Ticket>());
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Peliculas");
                entity.HasData(new Pelicula
                {
                    PeliculaId = 1,
                    Titulo = "Mad Max: Fury Road",
                    Sinopsis = "En un mundo post-apocalíptico, Max se une a Furiosa para escapar de un tirano y su ejército en una frenética persecución por el desierto.",
                    GeneroId = 1,
                    Poster = "https://http2.mlstatic.com/D_NQ_NP_843904-MLA40633054768_022020-O.webp",
                    Trailer = "https://www.youtube.com/watch?v=UxPhr1fElg0"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 2,
                    Titulo = "Guardians of the Galaxy",
                    Sinopsis = "Un grupo de inadaptados intergalácticos se unen para salvar la galaxia de una amenaza alienígena.",
                    GeneroId = 2,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNDIzMTk4NDYtMjg5OS00ZGI0LWJhZDYtMzdmZGY1YWU5ZGNkXkEyXkFqcGdeQXVyMTI5NzUyMTIz._V1_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=qdIuXCfUKM8"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 3,
                    Titulo = "The Social Dilemma",
                    Sinopsis = "Este documental examina cómo las redes sociales impactan en la sociedad y la vida de las personas",
                    GeneroId = 5,
                    Poster = "https://m.media-amazon.com/images/M/MV5BZGVjYjEzNmItMzc0My00Y2UyLWFlZjEtNzY5YTE4YTg2OGJlXkEyXkFqcGdeQXVyMjc5NDYwNTU@._V1_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=uaaC57tcci0"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 4,
                    Titulo = "Forrest Gump",
                    Sinopsis = "La vida de Forrest Gump, un hombre con discapacidad intelectual, que vive una vida extraordinaria.",
                    GeneroId = 6,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=XHhAG-YLdk8"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 5,
                    Titulo = "Harry Potter and the Sorcerer's Stone",
                    Sinopsis = "Un joven mago descubre su verdadera identidad y se aventura en un mundo de magia y misterio.",
                    GeneroId = 7,
                    Poster = "https://m.media-amazon.com/images/I/71x1RHSaEhL.jpg",
                    Trailer = "https://www.youtube.com/watch?v=VyHV0BRtdxo"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 6,
                    Titulo = "Forrest Gump",
                    Sinopsis = "La vida de Forrest Gump, un hombre con discapacidad intelectual, que vive una vida extraordinaria.",
                    GeneroId = 6,
                    Poster = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=XHhAG-YLdk8"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 7,
                    Titulo = "La La Land",
                    Sinopsis = "Un pianista y una actriz luchan por alcanzar sus sueños en la competitiva industria del entretenimiento de Los Ángeles.",
                    GeneroId = 8,
                    Poster = "https://flxt.tmsimg.com/assets/p12386480_p_v10_aj.jpg",
                    Trailer = "https://youtu.be/0pdqf4P9MB8"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 8,
                    Titulo = "Seven (Los siete pecados capitales)",
                    Sinopsis = "Dos detectives persiguen a un asesino en serie que comete sus crímenes basados en los siete pecados capitales.",
                    GeneroId = 9,
                    Poster = "https://image.tmdb.org/t/p/original/8U0mV8diqCo5y43jPxPHs4S2oXY.jpg",
                    Trailer = "https://youtu.be/q9BOtSBq-00"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 9,
                    Titulo = "Jurassic Park",
                    Sinopsis = " Un grupo de científicos se enfrenta a dinosaurios prehistóricos que escapan en un parque temático.",
                    GeneroId = 3,
                    Poster = "https://i.pinimg.com/originals/51/ba/64/51ba64b2e61f820e0e86bdd2f4c6e92c.jpg",
                    Trailer = "https://youtu.be/dLDkNge_AhE"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 10,
                    Titulo = "El Conjuro",
                    Sinopsis = "Un matrimonio de investigadores de lo paranormal ayuda a una familia aterrorizada por una presencia maligna en su casa.",
                    GeneroId = 10,
                    Poster = "https://tumbaabierta.com/wp-content/uploads/2013/04/tumbaabierta_the_CONJURING_cartel_internacional.jpg",
                    Trailer = "https://youtu.be/chAT_cFcQk0"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 11,
                    Titulo = "Deadpool",
                    Sinopsis = "Un antihéroe con habilidades regenerativas se embarca en una misión de venganza contra el hombre que arruinó su vida.",
                    GeneroId = 4,
                    Poster = "https://areajugones.sport.es/wp-content/uploads/2015/12/Deadpool-Poster1.jpg",
                    Trailer = "https://youtu.be/0JnRdfiUMa8"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 12,
                    Titulo = "Inception",
                    Sinopsis = "Un ladrón de sueños es contratado para implantar una idea en la mente de alguien durante un sueño profundo.",
                    GeneroId = 1,
                    Poster = "https://tumbaabierta.com/wp-content/uploads/2013/04/tumbaabierta_the_CONJURING_cartel_internacional.jpg",
                    Trailer = "https://youtu.be/YoHD9XEInc0"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 13,
                    Titulo = "The Shawshank Redemption",
                    Sinopsis = "La historia de amistad y redención de dos presos en una prisión de máxima seguridad.",
                    GeneroId = 6,
                    Poster = "https://c8.alamy.com/compes/2jh2myr/robbins-poster-la-redencion-de-shawshank-1994-2jh2myr.jpg",
                    Trailer = "https://youtu.be/NmzuHjWmXOc"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 14,
                    Titulo = "The Lord of the Rings: The Fellowship of the Ring",
                    Sinopsis = "Un grupo de aventureros se embarca en una búsqueda épica para destruir un poderoso anillo y salvar la Tierra Media.",
                    GeneroId = 7,
                    Poster = "https://i.pinimg.com/originals/f1/43/69/f14369fb56e47283f02038b920654056.jpg",
                    Trailer = "https://youtu.be/V75dMMIW2B4"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 15,
                    Titulo = "The Dark Knight",
                    Sinopsis = "Batman se enfrenta al Joker, un villano psicótico que amenaza la ciudad de Gotham.",
                    GeneroId = 9,
                    Poster = "https://i.pinimg.com/originals/cc/47/a5/cc47a507854dfe4ea145ebb4c9ae51c4.jpg",
                    Trailer = "https://youtu.be/EXeTwQWrcwY"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 16,
                    Titulo = "Interstellar",
                    Sinopsis = "Un grupo de astronautas viaja a través de un agujero de gusano en busca de un nuevo hogar para la humanidad.",
                    GeneroId = 3,
                    Poster = "https://m.media-amazon.com/images/I/71yTgkLsVSL._AC_UF1000,1000_QL80_.jpg",
                    Trailer = "https://youtu.be/UoSSbmD9vqc"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 17,
                    Titulo = "The Grand Budapest Hotel",
                    Sinopsis = "Las extravagantes aventuras de un conserje y su protegido en un elegante hotel europeo.",
                    GeneroId = 2,
                    Poster = "https://i.pinimg.com/originals/33/a2/3e/33a23efac95a568791d39c7f861ba571.jpg",
                    Trailer = "https://youtu.be/1Fg5iWmQjwk"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 18,
                    Titulo = "Psycho",
                    Sinopsis = "Un secretario se adentra en un motel regentado por un misterioso propietario con oscuros secretos.",
                    GeneroId = 10,
                    Poster = "https://i.pinimg.com/1200x/46/b6/7a/46b67ac7d75449489b8062fd9aabb580.jpg",
                    Trailer = "https://youtu.be/NG3-GlvKPcg"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 19,
                    Titulo = "Spirited Away",
                    Sinopsis = "Una niña se adentra en un mundo mágico y busca la forma de salvar a sus padres convertidos en cerdos.",
                    GeneroId = 7,
                    Poster = "https://i.pinimg.com/originals/d1/71/70/d17170965d7cb8e186976c87e0b2b1de.jpg",
                    Trailer = "https://youtu.be/ByXuk9QqQkk"

                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 20,
                    Titulo = "Pulp Fiction",
                    Sinopsis = "Varios personajes se entrelazan en una historia de crimen, violencia y humor negro en Los Ángeles.",
                    GeneroId = 9,
                    Poster = "https://i.pinimg.com/736x/b5/3d/5a/b53d5ab34f982f3f144f2f903d23dba7.jpg",
                    Trailer = "https://youtu.be/auCgsj0MV-M"

                });
            });
            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Salas");
                entity.HasData(new Sala { SalaId = 1, Nombre = "Gonza S 3D", Capacidad = 5 });
                entity.HasData(new Sala { SalaId = 2, Nombre = "Mati P 2D", Capacidad = 10 });
                entity.HasData(new Sala { SalaId = 3, Nombre = "AtiendoGente 4D", Capacidad = 15 });
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Generos");
                entity.HasData(new Genero { GeneroId = 1, Nombre = "Acción" });
                entity.HasData(new Genero { GeneroId = 2, Nombre = "Aventuras" });
                entity.HasData(new Genero { GeneroId = 3, Nombre = "Ciencia ficción" });
                entity.HasData(new Genero { GeneroId = 4, Nombre = "Comedia" });
                entity.HasData(new Genero { GeneroId = 5, Nombre = "Documental" });
                entity.HasData(new Genero { GeneroId = 6, Nombre = "Drama" });
                entity.HasData(new Genero { GeneroId = 7, Nombre = "Fantasía" });
                entity.HasData(new Genero { GeneroId = 8, Nombre = "Musical" });
                entity.HasData(new Genero { GeneroId = 9, Nombre = "Suspenso" });
                entity.HasData(new Genero { GeneroId = 10, Nombre = "Terror" });
            });
            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.ToTable("Funciones");

            });
        }
    }
}
