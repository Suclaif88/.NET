using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChocoByteAPI.Migrations
{
    public partial class RemoveIdentityFromCedula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminar la columna Cedula si ya existe
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Usuarios");

            // Volver a crear la columna Cedula sin la propiedad IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0); // Puedes poner un valor predeterminado, en este caso 0
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Si necesitas revertir la migración, restauramos la columna Cedula con la propiedad IDENTITY
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Usuarios");

            // Restauramos la columna Cedula con la propiedad IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1"); // Restauramos la propiedad IDENTITY
        }
    }
}
