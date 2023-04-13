using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel {
    public class Room {
        public int RoomID { get; set; }
        public int BedCount { get; set; }
        public bool HasKitchen { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasTerrace { get; set; }
        public decimal PricePerNight { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
