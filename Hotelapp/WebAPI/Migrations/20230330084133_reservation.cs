using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestPassnumber",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Payed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PaymentTarget = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    GuestPassnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Guests_GuestPassnumber",
                        column: x => x.GuestPassnumber,
                        principalTable: "Guests",
                        principalColumn: "Passnumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Startdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Enddate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GuestReservation",
                columns: table => new
                {
                    GuestsPassnumber = table.Column<int>(type: "int", nullable: false),
                    ReservationsReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestReservation", x => new { x.GuestsPassnumber, x.ReservationsReservationId });
                    table.ForeignKey(
                        name: "FK_GuestReservation_Guests_GuestsPassnumber",
                        column: x => x.GuestsPassnumber,
                        principalTable: "Guests",
                        principalColumn: "Passnumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestReservation_Reservation_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReservationRoom",
                columns: table => new
                {
                    ReservationsReservationId = table.Column<int>(type: "int", nullable: false),
                    RoomsRoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRoom", x => new { x.ReservationsReservationId, x.RoomsRoomID });
                    table.ForeignKey(
                        name: "FK_ReservationRoom_Reservation_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationRoom_Rooms_RoomsRoomID",
                        column: x => x.RoomsRoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GuestPassnumber",
                table: "Guests",
                column: "GuestPassnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_GuestPassnumber",
                table: "Bill",
                column: "GuestPassnumber");

            migrationBuilder.CreateIndex(
                name: "IX_GuestReservation_ReservationsReservationId",
                table: "GuestReservation",
                column: "ReservationsReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BillId",
                table: "Reservation",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRoom_RoomsRoomID",
                table: "ReservationRoom",
                column: "RoomsRoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Guests_GuestPassnumber",
                table: "Guests",
                column: "GuestPassnumber",
                principalTable: "Guests",
                principalColumn: "Passnumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Guests_GuestPassnumber",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "GuestReservation");

            migrationBuilder.DropTable(
                name: "ReservationRoom");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropIndex(
                name: "IX_Guests_GuestPassnumber",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "GuestPassnumber",
                table: "Guests");
        }
    }
}
