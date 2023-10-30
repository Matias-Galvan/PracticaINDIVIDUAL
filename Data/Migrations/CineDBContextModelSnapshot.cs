﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(CineDBContext))]
    partial class CineDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos", (string)null);

                    b.HasData(
                        new
                        {
                            GeneroId = 1,
                            Nombre = "Acción"
                        },
                        new
                        {
                            GeneroId = 2,
                            Nombre = "Aventuras"
                        },
                        new
                        {
                            GeneroId = 3,
                            Nombre = "Ciencia ficción"
                        },
                        new
                        {
                            GeneroId = 4,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            GeneroId = 5,
                            Nombre = "Documental"
                        },
                        new
                        {
                            GeneroId = 6,
                            Nombre = "Drama"
                        },
                        new
                        {
                            GeneroId = 7,
                            Nombre = "Fantasía"
                        },
                        new
                        {
                            GeneroId = 8,
                            Nombre = "Musical"
                        },
                        new
                        {
                            GeneroId = 9,
                            Nombre = "Suspenso"
                        },
                        new
                        {
                            GeneroId = 10,
                            Nombre = "Terror"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeliculaId"));

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PeliculaId");

                    b.HasIndex("Genero");

                    b.ToTable("Peliculas", (string)null);

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            Genero = 1,
                            Poster = "https://http2.mlstatic.com/D_NQ_NP_843904-MLA40633054768_022020-O.webp",
                            Sinopsis = "En un mundo post-apocalíptico, Max se une a Furiosa para escapar de un tirano y su ejército en una frenética persecución por el desierto.",
                            Titulo = "Mad Max: Fury Road",
                            Trailer = "https://www.youtube.com/watch?v=UxPhr1fElg0"
                        },
                        new
                        {
                            PeliculaId = 2,
                            Genero = 2,
                            Poster = "https://goo.su/w10Dq",
                            Sinopsis = "Un grupo de inadaptados intergalácticos se unen para salvar la galaxia de una amenaza alienígena.",
                            Titulo = "Guardians of the Galaxy",
                            Trailer = "https://www.youtube.com/watch?v=qdIuXCfUKM8"
                        },
                        new
                        {
                            PeliculaId = 3,
                            Genero = 5,
                            Poster = "https://goo.su/xcjUzn",
                            Sinopsis = "Este documental examina cómo las redes sociales impactan en la sociedad y la vida de las personas",
                            Titulo = "The Social Dilemma",
                            Trailer = "https://www.youtube.com/watch?v=uaaC57tcci0"
                        },
                        new
                        {
                            PeliculaId = 4,
                            Genero = 6,
                            Poster = "https://goo.su/jOvu9",
                            Sinopsis = "La vida de Forrest Gump, un hombre con discapacidad intelectual, que vive una vida extraordinaria.",
                            Titulo = "Forrest Gump",
                            Trailer = "https://www.youtube.com/watch?v=XHhAG-YLdk8"
                        },
                        new
                        {
                            PeliculaId = 5,
                            Genero = 7,
                            Poster = "https://m.media-amazon.com/images/I/71x1RHSaEhL.jpg",
                            Sinopsis = "Un joven mago descubre su verdadera identidad y se aventura en un mundo de magia y misterio.",
                            Titulo = "Harry Potter and the Sorcerer's Stone",
                            Trailer = "https://www.youtube.com/watch?v=VyHV0BRtdxo"
                        },
                        new
                        {
                            PeliculaId = 6,
                            Genero = 6,
                            Poster = "https://goo.su/jOvu9",
                            Sinopsis = "La vida de Forrest Gump, un hombre con discapacidad intelectual, que vive una vida extraordinaria.",
                            Titulo = "Forrest Gump",
                            Trailer = "https://www.youtube.com/watch?v=XHhAG-YLdk8"
                        },
                        new
                        {
                            PeliculaId = 7,
                            Genero = 8,
                            Poster = "https://flxt.tmsimg.com/assets/p12386480_p_v10_aj.jpg",
                            Sinopsis = "Un pianista y una actriz luchan por alcanzar sus sueños en la competitiva industria del entretenimiento de Los Ángeles.",
                            Titulo = "La La Land",
                            Trailer = "https://youtu.be/0pdqf4P9MB8"
                        },
                        new
                        {
                            PeliculaId = 8,
                            Genero = 9,
                            Poster = "https://image.tmdb.org/t/p/original/8U0mV8diqCo5y43jPxPHs4S2oXY.jpg",
                            Sinopsis = "Dos detectives persiguen a un asesino en serie que comete sus crímenes basados en los siete pecados capitales.",
                            Titulo = "Seven (Los siete pecados capitales)",
                            Trailer = "https://youtu.be/q9BOtSBq-00"
                        },
                        new
                        {
                            PeliculaId = 9,
                            Genero = 3,
                            Poster = "https://i.pinimg.com/originals/51/ba/64/51ba64b2e61f820e0e86bdd2f4c6e92c.jpg",
                            Sinopsis = " Un grupo de científicos se enfrenta a dinosaurios prehistóricos que escapan en un parque temático.",
                            Titulo = "Jurassic Park",
                            Trailer = "https://youtu.be/dLDkNge_AhE"
                        },
                        new
                        {
                            PeliculaId = 10,
                            Genero = 10,
                            Poster = "https://goo.su/rMlx",
                            Sinopsis = "Un matrimonio de investigadores de lo paranormal ayuda a una familia aterrorizada por una presencia maligna en su casa.",
                            Titulo = "El Conjuro",
                            Trailer = "https://youtu.be/chAT_cFcQk0"
                        },
                        new
                        {
                            PeliculaId = 11,
                            Genero = 4,
                            Poster = "https://areajugones.sport.es/wp-content/uploads/2015/12/Deadpool-Poster1.jpg",
                            Sinopsis = "Un antihéroe con habilidades regenerativas se embarca en una misión de venganza contra el hombre que arruinó su vida.",
                            Titulo = "Deadpool",
                            Trailer = "https://youtu.be/0JnRdfiUMa8"
                        },
                        new
                        {
                            PeliculaId = 12,
                            Genero = 1,
                            Poster = "https://goo.su/0Sx3zlk",
                            Sinopsis = "Un ladrón de sueños es contratado para implantar una idea en la mente de alguien durante un sueño profundo.",
                            Titulo = "Inception",
                            Trailer = "https://youtu.be/YoHD9XEInc0"
                        },
                        new
                        {
                            PeliculaId = 13,
                            Genero = 6,
                            Poster = "https://goo.su/qZvU0L",
                            Sinopsis = "La historia de amistad y redención de dos presos en una prisión de máxima seguridad.",
                            Titulo = "The Shawshank Redemption",
                            Trailer = "https://youtu.be/NmzuHjWmXOc"
                        },
                        new
                        {
                            PeliculaId = 14,
                            Genero = 7,
                            Poster = "https://i.pinimg.com/originals/f1/43/69/f14369fb56e47283f02038b920654056.jpg",
                            Sinopsis = "Un grupo de aventureros se embarca en una búsqueda épica para destruir un poderoso anillo y salvar la Tierra Media.",
                            Titulo = "The Lord of the Rings: The Fellowship of the Ring",
                            Trailer = "https://youtu.be/V75dMMIW2B4"
                        },
                        new
                        {
                            PeliculaId = 15,
                            Genero = 9,
                            Poster = "https://i.pinimg.com/originals/cc/47/a5/cc47a507854dfe4ea145ebb4c9ae51c4.jpg",
                            Sinopsis = "Batman se enfrenta al Joker, un villano psicótico que amenaza la ciudad de Gotham.",
                            Titulo = "The Dark Knight",
                            Trailer = "https://youtu.be/EXeTwQWrcwY"
                        },
                        new
                        {
                            PeliculaId = 16,
                            Genero = 3,
                            Poster = "https://m.media-amazon.com/images/I/71yTgkLsVSL._AC_UF1000,1000_QL80_.jpg",
                            Sinopsis = "Un grupo de astronautas viaja a través de un agujero de gusano en busca de un nuevo hogar para la humanidad.",
                            Titulo = "Interstellar",
                            Trailer = "https://youtu.be/UoSSbmD9vqc"
                        },
                        new
                        {
                            PeliculaId = 17,
                            Genero = 2,
                            Poster = "https://i.pinimg.com/originals/33/a2/3e/33a23efac95a568791d39c7f861ba571.jpg",
                            Sinopsis = "Las extravagantes aventuras de un conserje y su protegido en un elegante hotel europeo.",
                            Titulo = "The Grand Budapest Hotel",
                            Trailer = "https://youtu.be/1Fg5iWmQjwk"
                        },
                        new
                        {
                            PeliculaId = 18,
                            Genero = 10,
                            Poster = "https://i.pinimg.com/1200x/46/b6/7a/46b67ac7d75449489b8062fd9aabb580.jpg",
                            Sinopsis = "Un secretario se adentra en un motel regentado por un misterioso propietario con oscuros secretos.",
                            Titulo = "Psycho",
                            Trailer = "https://youtu.be/NG3-GlvKPcg"
                        },
                        new
                        {
                            PeliculaId = 19,
                            Genero = 7,
                            Poster = "https://i.pinimg.com/originals/d1/71/70/d17170965d7cb8e186976c87e0b2b1de.jpg",
                            Sinopsis = "Una niña se adentra en un mundo mágico y busca la forma de salvar a sus padres convertidos en cerdos.",
                            Titulo = "Spirited Away",
                            Trailer = "https://youtu.be/ByXuk9QqQkk"
                        },
                        new
                        {
                            PeliculaId = 20,
                            Genero = 9,
                            Poster = "https://i.pinimg.com/736x/b5/3d/5a/b53d5ab34f982f3f144f2f903d23dba7.jpg",
                            Sinopsis = "Varios personajes se entrelazan en una historia de crimen, violencia y humor negro en Los Ángeles.",
                            Titulo = "Pulp Fiction",
                            Trailer = "https://youtu.be/auCgsj0MV-M"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaId"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalaId");

                    b.ToTable("Salas", (string)null);

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            Capacidad = 5,
                            Nombre = "Gonza S 3D"
                        },
                        new
                        {
                            SalaId = 2,
                            Capacidad = 10,
                            Nombre = "Mati P 2D"
                        },
                        new
                        {
                            SalaId = 3,
                            Capacidad = 15,
                            Nombre = "AtiendoGente 4D"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketId", "FuncionId");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.HasOne("Domain.Entities.Pelicula", "Peliculas")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sala", "Salas")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peliculas");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.HasOne("Domain.Entities.Genero", "Generos")
                        .WithMany("Peliculas")
                        .HasForeignKey("Genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generos");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Funcion", "Funciones")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Sala", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
