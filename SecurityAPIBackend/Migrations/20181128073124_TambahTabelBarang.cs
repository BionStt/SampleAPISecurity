using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityAPIBackend.Migrations
{
    public partial class TambahTabelBarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barang",
                columns: table => new
                {
                    KodeBarang = table.Column<string>(nullable: false),
                    NamaBarang = table.Column<string>(nullable: true),
                    Jumlah = table.Column<int>(nullable: false),
                    HargaBeli = table.Column<decimal>(nullable: false),
                    HargaJual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barang", x => x.KodeBarang);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barang");
        }
    }
}
