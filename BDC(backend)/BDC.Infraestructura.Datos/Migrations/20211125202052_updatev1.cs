using Microsoft.EntityFrameworkCore.Migrations;

namespace BDC.Infraestructura.Datos.Migrations
{
    public partial class updatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb1Usuarios",
                newName: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "tb1Usuarios",
                newName: "Id");
        }
    }
}
