using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_project.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_SellerID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Product_SellerID",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerID",
                table: "Product",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_SellerID",
                table: "Product",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
