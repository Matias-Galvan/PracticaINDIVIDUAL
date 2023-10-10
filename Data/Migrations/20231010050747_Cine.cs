using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Cine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventuras" },
                    { 3, "Ciencia ficción" },
                    { 4, "Comedia" },
                    { 5, "Documental" },
                    { 6, "Drama" },
                    { 7, "Fantasía" },
                    { 8, "Musical" },
                    { 9, "Suspenso" },
                    { 10, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 5, "Gonza S 3D" },
                    { 2, 10, "Mati P 2D" },
                    { 3, 15, "AtiendoGente 4D" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Genero", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 1, "https://http2.mlstatic.com/D_NQ_NP_843904-MLA40633054768_022020-O.webp", "En un mundo post-apocalíptico, Max se une a Furiosa para escapar de un tirano y su ejército en una frenética persecución por el desierto.", "Mad Max: Fury Road", "https://www.youtube.com/watch?v=UxPhr1fElg0" },
                    { 2, 2, "https://goo.su/w10Dq", "Un grupo de inadaptados intergalácticos se unen para salvar la galaxia de una amenaza alienígena.", "Guardians of the Galaxy", "https://www.youtube.com/watch?v=qdIuXCfUKM8" },
                    { 3, 5, "https://goo.su/xcjUzn", "Este documental examina cómo las redes sociales impactan en la sociedad y la vida de las personas", "The Social Dilemma", "https://www.youtube.com/watch?v=uaaC57tcci0" },
                    { 4, 6, "https://goo.su/jOvu9", "La vida de Forrest Gump, un hombre con discapacidad intelectual, que vive una vida extraordinaria.", "Forrest Gump", "https://www.youtube.com/watch?v=XHhAG-YLdk8" },
                    { 5, 7, "https://m.media-amazon.com/images/I/71x1RHSaEhL.jpg", "Un joven mago descubre su verdadera identidad y se aventura en un mundo de magia y misterio.", "Harry Potter and the Sorcerer's Stone", "https://www.youtube.com/watch?v=VyHV0BRtdxo" },
                    { 6, 6, "https://goo.su/jOvu9", "La vida de Forrest Gump, un hombre con discapacidad intelectual, que vive una vida extraordinaria.", "Forrest Gump", "https://www.youtube.com/watch?v=XHhAG-YLdk8" },
                    { 7, 8, "https://flxt.tmsimg.com/assets/p12386480_p_v10_aj.jpg", "Un pianista y una actriz luchan por alcanzar sus sueños en la competitiva industria del entretenimiento de Los Ángeles.", "La La Land", "https://youtu.be/0pdqf4P9MB8" },
                    { 8, 9, "https://image.tmdb.org/t/p/original/8U0mV8diqCo5y43jPxPHs4S2oXY.jpg", "Dos detectives persiguen a un asesino en serie que comete sus crímenes basados en los siete pecados capitales.", "Seven (Los siete pecados capitales)", "https://youtu.be/q9BOtSBq-00" },
                    { 9, 3, "https://i.pinimg.com/originals/51/ba/64/51ba64b2e61f820e0e86bdd2f4c6e92c.jpg", " Un grupo de científicos se enfrenta a dinosaurios prehistóricos que escapan en un parque temático.", "Jurassic Park", "https://youtu.be/dLDkNge_AhE" },
                    { 10, 10, "https://goo.su/rMlx", "Un matrimonio de investigadores de lo paranormal ayuda a una familia aterrorizada por una presencia maligna en su casa.", "El Conjuro", "https://youtu.be/chAT_cFcQk0" },
                    { 11, 4, "https://areajugones.sport.es/wp-content/uploads/2015/12/Deadpool-Poster1.jpg", "Un antihéroe con habilidades regenerativas se embarca en una misión de venganza contra el hombre que arruinó su vida.", "Deadpool", "https://youtu.be/0JnRdfiUMa8" },
                    { 12, 1, "https://goo.su/0Sx3zlk", "Un ladrón de sueños es contratado para implantar una idea en la mente de alguien durante un sueño profundo.", "Inception", "https://youtu.be/YoHD9XEInc0" },
                    { 13, 6, "https://goo.su/qZvU0L", "La historia de amistad y redención de dos presos en una prisión de máxima seguridad.", "The Shawshank Redemption", "https://youtu.be/NmzuHjWmXOc" },
                    { 14, 7, "https://i.pinimg.com/originals/f1/43/69/f14369fb56e47283f02038b920654056.jpg", "Un grupo de aventureros se embarca en una búsqueda épica para destruir un poderoso anillo y salvar la Tierra Media.", "The Lord of the Rings: The Fellowship of the Ring", "https://youtu.be/V75dMMIW2B4" },
                    { 15, 9, "https://i.pinimg.com/originals/cc/47/a5/cc47a507854dfe4ea145ebb4c9ae51c4.jpg", "Batman se enfrenta al Joker, un villano psicótico que amenaza la ciudad de Gotham.", "The Dark Knight", "https://youtu.be/EXeTwQWrcwY" },
                    { 16, 3, "https://m.media-amazon.com/images/I/71yTgkLsVSL._AC_UF1000,1000_QL80_.jpg", "Un grupo de astronautas viaja a través de un agujero de gusano en busca de un nuevo hogar para la humanidad.", "Interstellar", "https://youtu.be/UoSSbmD9vqc" },
                    { 17, 2, "https://i.pinimg.com/originals/33/a2/3e/33a23efac95a568791d39c7f861ba571.jpg", "Las extravagantes aventuras de un conserje y su protegido en un elegante hotel europeo.", "The Grand Budapest Hotel", "https://youtu.be/1Fg5iWmQjwk" },
                    { 18, 10, "https://i.pinimg.com/1200x/46/b6/7a/46b67ac7d75449489b8062fd9aabb580.jpg", "Un secretario se adentra en un motel regentado por un misterioso propietario con oscuros secretos.", "Psycho", "https://youtu.be/NG3-GlvKPcg" },
                    { 19, 7, "https://i.pinimg.com/originals/d1/71/70/d17170965d7cb8e186976c87e0b2b1de.jpg", "Una niña se adentra en un mundo mágico y busca la forma de salvar a sus padres convertidos en cerdos.", "Spirited Away", "https://youtu.be/ByXuk9QqQkk" },
                    { 20, 9, "https://i.pinimg.com/736x/b5/3d/5a/b53d5ab34f982f3f144f2f903d23dba7.jpg", "Varios personajes se entrelazan en una historia de crimen, violencia y humor negro en Los Ángeles.", "Pulp Fiction", "https://youtu.be/auCgsj0MV-M" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Genero",
                table: "Peliculas",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
