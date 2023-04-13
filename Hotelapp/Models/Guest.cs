using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel {
    public class Guest {
        
        public int Passnumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string EMail { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; } = new Address();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
