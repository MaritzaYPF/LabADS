using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class RelacionAsignacionGrupos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materias_idProfesor",
                table: "Grupos");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Profesores_idProfesor",
                table: "Grupos",
                column: "idProfesor",
                principalTable: "Profesores",
                principalColumn: "idProfesor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Profesores_idProfesor",
                table: "Grupos");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materias_idProfesor",
                table: "Grupos",
                column: "idProfesor",
                principalTable: "Materias",
                principalColumn: "idMateria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
