using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel {
    public class Reservation {
        public int ReservationId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Guest> Guests { get; set; } = new List<Guest>();
        public Bill Bill { get; set; } = new Bill();


    }
}
