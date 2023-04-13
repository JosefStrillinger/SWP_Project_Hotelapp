using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class guest_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressGuest");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_AddressId",
                table: "Guests",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Addresses_AddressId",
                table: "Guests",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Addresses_AddressId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_AddressId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Guests");

            migrationBuilder.CreateTable(
                name: "AddressGuest",
                columns: table => new
                {
                    AddressesAddressId = table.Column<int>(type: "int", nullable: false),
                    GuestsPassnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressGuest", x => new { x.AddressesAddressId, x.GuestsPassnumber });
                    table.ForeignKey(
                        name: "FK_AddressGuest_Addresses_AddressesAddressId",
                        column: x => x.AddressesAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressGuest_Guests_GuestsPassnumber",
                        column: x => x.GuestsPassnumber,
                        principalTable: "Guests",
                        principalColumn: "Passnumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AddressGuest_GuestsPassnumber",
                table: "AddressGuest",
                column: "GuestsPassnumber");
        }
    }
}
