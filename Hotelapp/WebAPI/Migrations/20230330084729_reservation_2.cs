using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class reservation_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Guests_GuestPassnumber",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestReservation_Reservation_ReservationsReservationId",
                table: "GuestReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Bill_BillId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRoom_Reservation_ReservationsReservationId",
                table: "ReservationRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "Bills");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_BillId",
                table: "Reservations",
                newName: "IX_Reservations_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_GuestPassnumber",
                table: "Bills",
                newName: "IX_Bills_GuestPassnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bills",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Guests_GuestPassnumber",
                table: "Bills",
                column: "GuestPassnumber",
                principalTable: "Guests",
                principalColumn: "Passnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestReservation_Reservations_ReservationsReservationId",
                table: "GuestReservation",
                column: "ReservationsReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRoom_Reservations_ReservationsReservationId",
                table: "ReservationRoom",
                column: "ReservationsReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Bills_BillId",
                table: "Reservations",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Guests_GuestPassnumber",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestReservation_Reservations_ReservationsReservationId",
                table: "GuestReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRoom_Reservations_ReservationsReservationId",
                table: "ReservationRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Bills_BillId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bills");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bill");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BillId",
                table: "Reservation",
                newName: "IX_Reservation_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_GuestPassnumber",
                table: "Bill",
                newName: "IX_Bill_GuestPassnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Guests_GuestPassnumber",
                table: "Bill",
                column: "GuestPassnumber",
                principalTable: "Guests",
                principalColumn: "Passnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestReservation_Reservation_ReservationsReservationId",
                table: "GuestReservation",
                column: "ReservationsReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Bill_BillId",
                table: "Reservation",
                column: "BillId",
                principalTable: "Bill",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRoom_Reservation_ReservationsReservationId",
                table: "ReservationRoom",
                column: "ReservationsReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
