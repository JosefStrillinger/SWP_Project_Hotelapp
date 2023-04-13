using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel {
    public class Address {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public List<Guest> Guests { get; set; } = new List<Guest>();
    }
}
