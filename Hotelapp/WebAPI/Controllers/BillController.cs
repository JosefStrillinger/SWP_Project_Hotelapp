using Hotel;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DB;

namespace WebAPI.Controllers {

    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase {
        private HotelContext _hotelContext;

        public BillController(HotelContext hotelContext) {
            this._hotelContext = hotelContext;
        }

        [HttpGet]
        [Route("bills")]
        public async Task<IActionResult> AllBills() {
            List<Bill> values = new List<Bill>();
            values.AddRange(this._hotelContext.Bills);
            return new JsonResult(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBillById(int id) {
            Bill r = await this._hotelContext.Bills.FindAsync(id);
            if (r != null) {
                return new JsonResult(r);
            }
            return new JsonResult(null);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteBillById(int id) {
            Bill r = await this._hotelContext.Bills.FindAsync(id);
            if (r != null) {
                _hotelContext.Bills.Remove(r);
                int result = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(result);
            }
            return new JsonResult(false);
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> PostBill(Bill bill) {
            if (bill == null) {
                return new JsonResult("Guest does not exist");
            }
            this._hotelContext.Add(bill);
            try {
                await this._hotelContext.SaveChangesAsync();
                return new JsonResult("Success");
            } catch (Exception ex) {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateBill(int id, Bill bill) {
            if (bill == null) {
                return new JsonResult(false);
            }
            Bill to_update = await this._hotelContext.Bills.FindAsync(id);
            if (to_update != null) {
                to_update.Payed = bill.Payed;
                to_update.PaymentTarget = bill.PaymentTarget;
                to_update.Price = bill.Price;
                to_update.Discount = bill.Discount;
                to_update.PaymentMethod = bill.PaymentMethod;
                to_update.Guest =  bill.Guest;
                to_update.Reservations = bill.Reservations;
                int res = await this._hotelContext.SaveChangesAsync();
                return new JsonResult(res == 1);
            } else {
                return new JsonResult(false);
            }

        }
    }
}
