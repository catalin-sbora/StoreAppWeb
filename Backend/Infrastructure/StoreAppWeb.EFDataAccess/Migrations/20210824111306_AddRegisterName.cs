using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppWeb.EFDataAccess.Migrations
{
    public partial class AddRegisterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CashRegister",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CashRegister");
        }
    }
}
