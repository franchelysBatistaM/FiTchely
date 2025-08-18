using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActividadesDeportivas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosDeportivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosDeportivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioDeportivoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: false),
                    CaloriasQuemadas = table.Column<float>(type: "real", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesFisicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadesFisicas_UsuariosDeportivos_UsuarioDeportivoId",
                        column: x => x.UsuarioDeportivoId,
                        principalTable: "UsuariosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadisticasProgreso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioDeportivoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    IMC = table.Column<float>(type: "real", nullable: false),
                    GrasaCorporal = table.Column<float>(type: "real", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadisticasProgreso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadisticasProgreso_UsuariosDeportivos_UsuarioDeportivoId",
                        column: x => x.UsuarioDeportivoId,
                        principalTable: "UsuariosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumenesDiariosFitbit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioDeportivoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaloriasQuemadas = table.Column<int>(type: "int", nullable: false),
                    Pasos = table.Column<int>(type: "int", nullable: false),
                    MinutosSedentarios = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumenesDiariosFitbit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumenesDiariosFitbit_UsuariosDeportivos_UsuarioDeportivoId",
                        column: x => x.UsuarioDeportivoId,
                        principalTable: "UsuariosDeportivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesFisicas_UsuarioDeportivoId",
                table: "ActividadesFisicas",
                column: "UsuarioDeportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadisticasProgreso_UsuarioDeportivoId",
                table: "EstadisticasProgreso",
                column: "UsuarioDeportivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumenesDiariosFitbit_UsuarioDeportivoId",
                table: "ResumenesDiariosFitbit",
                column: "UsuarioDeportivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadesFisicas");

            migrationBuilder.DropTable(
                name: "EstadisticasProgreso");

            migrationBuilder.DropTable(
                name: "ResumenesDiariosFitbit");

            migrationBuilder.DropTable(
                name: "UsuariosDeportivos");
        }
    }
}
