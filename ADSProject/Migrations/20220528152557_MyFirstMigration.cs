using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoCarrera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombresCarrera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    idGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    idProfesor = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false),
                    Ciclo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Anio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.idGrupo);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    idProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombresProfesor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidosProfesor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoProfesor = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.idProfesor);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    idEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombresEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellidosEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigoEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.idEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Carreras_idCarrera",
                        column: x => x.idCarrera,
                        principalTable: "Carreras",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    idMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombresMateria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.idMateria);
                    table.ForeignKey(
                        name: "FK_Materias_Carreras_idCarrera",
                        column: x => x.idCarrera,
                        principalTable: "Carreras",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionGrupos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idGrupo = table.Column<int>(type: "int", nullable: false),
                    idEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionGrupos", x => x.id);
                    table.ForeignKey(
                        name: "FK_AsignacionGrupos_Estudiantes_idEstudiante",
                        column: x => x.idEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "idEstudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionGrupos_Grupos_idGrupo",
                        column: x => x.idGrupo,
                        principalTable: "Grupos",
                        principalColumn: "idGrupo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionGrupos_idEstudiante",
                table: "AsignacionGrupos",
                column: "idEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionGrupos_idGrupo",
                table: "AsignacionGrupos",
                column: "idGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_idCarrera",
                table: "Estudiantes",
                column: "idCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_idCarrera",
                table: "Materias",
                column: "idCarrera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionGrupos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Carreras");
        }
    }
}
