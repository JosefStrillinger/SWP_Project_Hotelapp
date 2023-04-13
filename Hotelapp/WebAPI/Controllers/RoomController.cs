using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DB;
using Hotel;

namespace WebAPI.Controllers {

    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase {

        private HotelContext _hotelContext;

        public RoomController(HotelContext hotelContext) {
            this._hotelContext = hotelContext;
        }

        [HttpGet]
        [Route("rooms")]
        public async Task<IActionResult> AllRooms() {
            List<Room> values = new List<Room>();
            values.AddRange(this._hotelContext.Rooms);
            return new JsonResult(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoomById(int id) {
            Room r = await this._hotelContext.Rooms.FindAsync(id);
            if (r != null) {
                return new JsonResult(r);
            }
            return new JsonResult(null);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteRoomById(int id) {
            Room r = await this._hotelContext.Rooms.FindAsync(id);
            if (r != null) {
                _hotelContext.Rooms.Remove(r);
                int result = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(result);
            }
            return new JsonResult(false);
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> PostRoom(Room room) {
            if (room == null) {
                return new JsonResult("Room does not exist");
            }
            this._hotelContext.Add(room);
            try {
                await this._hotelContext.SaveChangesAsync();
                return new JsonResult("Success");
            } catch (Exception ex) {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room room) {
            if (room == null) {
                return new JsonResult(false);
            }
            Room to_update = await this._hotelContext.Rooms.FindAsync(id);
            if (to_update != null) { 
                to_update.PricePerNight = room.PricePerNight;
                to_update.HasKitchen = room.HasKitchen;
                to_update.HasBalcony = room.HasBalcony;
                to_update.HasTerrace= room.HasTerrace;
                int res = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(res == 1);
            } else {
                return new JsonResult(false);
            }

        }
    }
}
