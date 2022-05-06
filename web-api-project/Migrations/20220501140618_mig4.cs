using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_project.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Phone",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Phone");

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
