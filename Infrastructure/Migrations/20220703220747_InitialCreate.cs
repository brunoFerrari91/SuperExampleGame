using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destrezas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destrezas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostoOro = table.Column<int>(type: "int", nullable: false),
                    CostoDiamante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oro = table.Column<int>(type: "int", nullable: false),
                    Diamantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestrezaItem",
                columns: table => new
                {
                    DestrezasId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestrezaItem", x => new { x.DestrezasId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_DestrezaItem_Destrezas_DestrezasId",
                        column: x => x.DestrezasId,
                        principalTable: "Destrezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestrezaItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guerreros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guerreros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guerreros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestrezaGuerreros",
                columns: table => new
                {
                    DestrezaId = table.Column<int>(type: "int", nullable: false),
                    GuerreroId = table.Column<int>(type: "int", nullable: false),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    Grado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestrezaGuerreros", x => new { x.DestrezaId, x.GuerreroId });
                    table.ForeignKey(
                        name: "FK_DestrezaGuerreros_Destrezas_DestrezaId",
                        column: x => x.DestrezaId,
                        principalTable: "Destrezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestrezaGuerreros_Guerreros_GuerreroId",
                        column: x => x.GuerreroId,
                        principalTable: "Guerreros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestrezaGuerreros_Niveles_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestrezaGuerreros_GuerreroId",
                table: "DestrezaGuerreros",
                column: "GuerreroId");

            migrationBuilder.CreateIndex(
                name: "IX_DestrezaGuerreros_NivelId",
                table: "DestrezaGuerreros",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_DestrezaItem_ItemsId",
                table: "DestrezaItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Guerreros_UsuarioId",
                table: "Guerreros",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestrezaGuerreros");

            migrationBuilder.DropTable(
                name: "DestrezaItem");

            migrationBuilder.DropTable(
                name: "Guerreros");

            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropTable(
                name: "Destrezas");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
