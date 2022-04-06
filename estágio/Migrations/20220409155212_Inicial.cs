using Microsoft.EntityFrameworkCore.Migrations;

namespace estágio.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "entidade",
                columns: table => new
                {
                    nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "longtext", precision: 10, scale: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entidade", x => x.nome);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "entidade",
                columns: new[] { "nome", "data", "status" },
                values: new object[] { "Consertar carro", "01/04/2002", "concluido" });

            migrationBuilder.InsertData(
                table: "entidade",
                columns: new[] { "nome", "data", "status" },
                values: new object[] { "Cortar grama", "03/04/2002", "Em processo" });

            migrationBuilder.InsertData(
                table: "entidade",
                columns: new[] { "nome", "data", "status" },
                values: new object[] { "Montar computador", "02/04/2002", "Em processo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entidade");
        }
    }
}
