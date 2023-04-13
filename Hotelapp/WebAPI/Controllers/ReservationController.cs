using Hotel;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DB;

namespace WebAPI.Controllers {
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase {
        private HotelContext _hotelContext;

        public ReservationController(HotelContext hotelContext) {
            this._hotelContext = hotelContext;
        }

        [HttpGet]
        [Route("reservations")]
        public async Task<IActionResult> AllReservations() {
            List<Reservation> values = new List<Reservation>();
            values.AddRange(this._hotelContext.Reservations);
            return new JsonResult(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetReservationById(int id) {
            Reservation r = await this._hotelContext.Reservations.FindAsync(id);
            if (r != null) {
                return new JsonResult(r);
            }
            return new JsonResult(null);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteReservationById(int id) {
            Reservation r = await this._hotelContext.Reservations.FindAsync(id);
            if (r != null) {
                _hotelContext.Reservations.Remove(r);
                int result = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(result);
            }
            return new JsonResult(false);
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> PostReservation(Reservation reservation) {
            if (reservation == null) {
                return new JsonResult("Guest does not exist");
            }
            this._hotelContext.Add(reservation);
            try {
                await this._hotelContext.SaveChangesAsync();
                return new JsonResult("Success");
            } catch (Exception ex) {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateReservation(int id, Reservation reservation) {
            if (reservation == null) {
                return new JsonResult(false);
            }
            Reservation to_update = await this._hotelContext.Reservations.FindAsync(id);
            if (to_update != null) {
                to_update.Startdate = reservation.Startdate;
                to_update.Enddate = reservation.Enddate;
                to_update.Rooms = reservation.Rooms;
                to_update.Guests = reservation.Guests;
                to_update.Bill = reservation.Bill;
                int res = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(res == 1);
            } else {
                return new JsonResult(false);
            }

        }
    }
}
