using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDC.Infraestructura.Datos.Migrations
{
    public partial class finalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb1Aplicativos",
                columns: table => new
                {
                    id_aplicativo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Aplicativos", x => x.id_aplicativo);
                });

            migrationBuilder.CreateTable(
                name: "tb1ClienteAplicacion",
                columns: table => new
                {
                    id_aplicativo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1ClienteAplicacion", x => new { x.id_aplicativo, x.id_cliente });
                });

            migrationBuilder.CreateTable(
                name: "tb1ClienteProducto",
                columns: table => new
                {
                    id_producto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1ClienteProducto", x => new { x.id_producto, x.id_cliente });
                });

            migrationBuilder.CreateTable(
                name: "tb1Clientes",
                columns: table => new
                {
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Clientes", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tb1Negocio_Lineas",
                columns: table => new
                {
                    id_negocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagen_path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Negocio_Lineas", x => x.id_negocio);
                });

            migrationBuilder.CreateTable(
                name: "tb1NegocioCliente",
                columns: table => new
                {
                    id_cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_negocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1NegocioCliente", x => new { x.id_negocio, x.id_cliente });
                });

            migrationBuilder.CreateTable(
                name: "tb1Productos",
                columns: table => new
                {
                    id_producto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Productos", x => x.id_producto);
                });

            migrationBuilder.CreateTable(
                name: "tb1Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb1Codigos",
                columns: table => new
                {
                    id_codigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo_aux1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo_aux2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo_aux3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_producto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_aplicativo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Codigos", x => x.id_codigo);
                    table.ForeignKey(
                        name: "FK_tb1Codigos_tb1Aplicativos_id_aplicativo",
                        column: x => x.id_aplicativo,
                        principalTable: "tb1Aplicativos",
                        principalColumn: "id_aplicativo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb1Codigos_tb1Productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "tb1Productos",
                        principalColumn: "id_producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb1Comentarios",
                columns: table => new
                {
                    id_comentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comentarioText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb1Comentarios", x => x.id_comentario);
                    table.ForeignKey(
                        name: "FK_tb1Comentarios_tb1Usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "tb1Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb1Codigos_id_aplicativo",
                table: "tb1Codigos",
                column: "id_aplicativo");

            migrationBuilder.CreateIndex(
                name: "IX_tb1Codigos_id_producto",
                table: "tb1Codigos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_tb1Comentarios_id_usuario",
                table: "tb1Comentarios",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb1ClienteAplicacion");

            migrationBuilder.DropTable(
                name: "tb1ClienteProducto");

            migrationBuilder.DropTable(
                name: "tb1Clientes");

            migrationBuilder.DropTable(
                name: "tb1Codigos");

            migrationBuilder.DropTable(
                name: "tb1Comentarios");

            migrationBuilder.DropTable(
                name: "tb1Negocio_Lineas");

            migrationBuilder.DropTable(
                name: "tb1NegocioCliente");

            migrationBuilder.DropTable(
                name: "tb1Aplicativos");

            migrationBuilder.DropTable(
                name: "tb1Productos");

            migrationBuilder.DropTable(
                name: "tb1Usuarios");
        }
    }
}
