using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppWeb.EFDataAccess.Migrations
{
    public partial class SaveLastRegisterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashRegister_Stores_StoreId",
                table: "CashRegister");

            migrationBuilder.AddColumn<int>(
                name: "LastCashRegister",
                table: "Administrators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegister_Stores_StoreId",
                table: "CashRegister",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashRegister_Stores_StoreId",
                table: "CashRegister");

            migrationBuilder.DropColumn(
                name: "LastCashRegister",
                table: "Administrators");

            migrationBuilder.AddForeignKey(
                name: "FK_CashRegister_Stores_StoreId",
                table: "CashRegister",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
