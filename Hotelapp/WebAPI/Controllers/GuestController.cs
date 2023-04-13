using Hotel;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DB;

namespace WebAPI.Controllers {
    [Route("api/guest")]
    [ApiController]
    public class GuestController : ControllerBase {
        private HotelContext _hotelContext;

        public GuestController(HotelContext hotelContext) {
            this._hotelContext = hotelContext;
        }

        [HttpGet]
        [Route("guests")]
        public async Task<IActionResult> AllGuests() {
            List<Guest> values = new List<Guest>();
            values.AddRange(this._hotelContext.Guests);
            return new JsonResult(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGestById(int id) {
            Guest r = await this._hotelContext.Guests.FindAsync(id);
            if (r != null) {
                return new JsonResult(r);
            }
            return new JsonResult(null);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteGuestById(int id) {
            Guest r = await this._hotelContext.Guests.FindAsync(id);
            if (r != null) {
                _hotelContext.Guests.Remove(r);
                int result = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(result);
            }
            return new JsonResult(false);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterGuest(Guest guest) {
            if (guest == null) {
                return new JsonResult("Guest does not exist");
            }
            this._hotelContext.Add(guest);// Either add guest to address or make address nullable
            try {
                await this._hotelContext.SaveChangesAsync();
                return new JsonResult("Success");
            } catch (Exception ex) {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateGuest(int id, Guest guest) {
            if (guest == null) {
                return new JsonResult(false);
            }
            Guest to_update = await this._hotelContext.Guests.FindAsync(id);
            if (to_update != null) {
                to_update.Passnumber = guest.Passnumber;
                to_update.Firstname = guest.Firstname;
                to_update.Lastname = guest.Lastname;
                to_update.Birthdate = guest.Birthdate;
                to_update.EMail = guest.EMail;
                to_update.Gender = guest.Gender;
                to_update.Address = guest.Address;
                int res = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(res == 1);
            } else {
                return new JsonResult(false);
            }

        }
    }
}
