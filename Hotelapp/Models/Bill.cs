using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel {
    public class Bill {
        public int BillId { get; set; }
        public bool Payed { get; set; }
        public DateTime PaymentTarget { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Guest Guest { get; set; } = new Guest();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
