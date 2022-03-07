using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFundi.Web.Migrations
{
    public partial class fundiProfileAddressIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "FundiProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FundiProfiles_AddressId",
                table: "FundiProfiles",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundiProfiles_Addresses_AddressId",
                table: "FundiProfiles",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundiProfiles_Addresses_AddressId",
                table: "FundiProfiles");

            migrationBuilder.DropIndex(
                name: "IX_FundiProfiles_AddressId",
                table: "FundiProfiles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "FundiProfiles");
        }
    }
}
