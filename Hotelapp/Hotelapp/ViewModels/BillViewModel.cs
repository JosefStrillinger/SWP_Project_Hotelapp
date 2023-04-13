using Hotel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotelapp.ViewModels {
    public class BillViewModel : INotifyPropertyChanged{
        public event PropertyChangedEventHandler PropertyChanged;

        public bool _payed;
        public DateTime _paymentTarget;
        public decimal _price;
        public decimal _discount;
        public PaymentMethod _paymentMethod;
        public Guest _guest;
        public int _guestId;
        public int _reservationId;
        public DateTime _startDate;
        public DateTime _endDate;
        public Bill _bill;
        public Room _room;
        public int _billId;
        public int _roomId;

        public DateTime Startdate {
            get { return _startDate; }
            set {
                if (value != _startDate) {
                    _startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Enddate {
            get { return _endDate; }
            set {
                if (value != _endDate) {
                    _endDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public Reservation _reservation;
        public ObservableCollection<Reservation> Reservations { get; set; } = new ObservableCollection<Reservation>();
        public ObservableCollection<int> ReservationItems { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> GuestItems { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();
        public ObservableCollection<int> RoomItems { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<Guest> Guests { get; set; } = new ObservableCollection<Guest>();
        public ObservableCollection<Guest> AllGuests { get; set; } = new ObservableCollection<Guest>();
        public ObservableCollection<Room> AllRooms { get; set; } = new ObservableCollection<Room>();

        public bool Payed {
            get { return _payed; }
            set {
                if (value != _payed) {
                    _payed = value;
                    OnPropertyChanged();
                }
            }
        }
        // TODO: Fertig

        public DateTime PaymentTarget {
            get { return _paymentTarget; }
            set {
                if (value != _paymentTarget) {
                    _paymentTarget = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price {
            get { return _price; }
            set {
                if (value != _price) {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Discount {
            get { return _discount; }
            set {
                if (value != _discount) {
                    _discount = value;
                    OnPropertyChanged();
                }
            }
        }

        public PaymentMethod PaymentMethod {
            get { return _paymentMethod; }
            set {
                if (value != _paymentMethod) {
                    _paymentMethod = value;
                    OnPropertyChanged();
                }
            }
        }

        public Guest Guest {
            get { return _guest; }
            set {
                if (value != _guest) {
                    _guest = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ReservationSel {
            get { return _reservationId; }
            set {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7500");

                var response = client.GetAsync("/api/reservation/" + value);
                Console.WriteLine(response);
                if (response != null) {
                    string result = response.ToString();
                    var Reservation = JsonConvert.DeserializeObject<Reservation>(result);
                    if (!Reservations.Contains(Reservation)) {
                        Reservations.Add(Reservation);
                        _reservationId = value;
                        OnPropertyChanged();
                    }
                    Console.WriteLine(Reservations);
                }
            }
        }

        public int GuestSel {
            get { return _guestId;  }
            set {
                List<Guest> guests = AllGuests.ToList();
                var guests2 = guests.Where(guest => guest.Passnumber == value).ToList();
                Guest guest = guests2[0];
                if (guest != null && !Guests.Contains(guest)) {
                    Guests.Add(guest);
                    _guest = guest;
                    _guestId = value;
                    OnPropertyChanged();
                }
                //Console.WriteLine(Guest);
                
            }
        }

        public int RoomSel {
            get { return _roomId; }
            set {
                List<Room> rooms = AllRooms.ToList();
                var rooms2 = rooms.Where(room => room.RoomID == value).ToList();
                Room room = rooms2[0];
                if (rooms != null && !Rooms.Contains(room)) {
                    Rooms.Add(room);
                    _roomId = value;
                    OnPropertyChanged();
                }

            }
        }

        public List<string> PaymentMethods {
            get {
                return Enum.GetNames<PaymentMethod>().ToList();
            }
        }


        public BillViewModel() {
            this.CmdBillCreate = new Command(OnBillCreate);
        }

        public ICommand CmdBillCreate { get; private set; }

        private async void OnBillCreate() {
            Reservation reservation = new Reservation() {
                Startdate = this.Startdate,
                Enddate = this.Enddate,
                Rooms = Rooms.ToList(),
                Guests = Guests.ToList()

            };

            Bill bill = new Bill() {
                Payed = this.Payed,
                PaymentTarget = this.PaymentTarget,
                Price = this.Price,
                Discount = this.Discount,
                PaymentMethod = this.PaymentMethod,
                Guest = this.Guest,
            };
            bill.Reservations.Add(reservation);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7500");

            var response = await client.PostAsJsonAsync<Bill>("/api/bill/post", bill);

            Console.WriteLine(response);
        }

        public async void OnShowBill() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7500");

            //var response = await client.GetAsync("/api/reservation/reservations");
            //Console.WriteLine(response);
            //if (response != null) {
            //    ReservationItems.Clear();
            //    string result = await response.Content.ReadAsStringAsync();
            //    var listReservations = JsonConvert.DeserializeObject<List<Reservation>>(result);
            //    listReservations.ForEach(reserv => ReservationItems.Add(reserv.ReservationId));
            //    //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
            //    Console.WriteLine(ReservationItems);
            //}

            var responseGuest = await client.GetAsync("/api/guest/guests");
            Console.WriteLine(responseGuest);
            if (responseGuest != null) {
                GuestItems.Clear();
                string result = await responseGuest.Content.ReadAsStringAsync();
                var listGuest = JsonConvert.DeserializeObject<List<Guest>>(result);
                listGuest.ForEach(guest => GuestItems.Add(guest.Passnumber));
                listGuest.ForEach(guest => AllGuests.Add(guest));
                //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
                Console.WriteLine(GuestItems);
            }

            var responseRoom = await client.GetAsync("/api/room/rooms");
            Console.WriteLine(responseRoom);
            if (responseRoom != null) {
                RoomItems.Clear();
                string result = await responseRoom.Content.ReadAsStringAsync();
                var listRoom = JsonConvert.DeserializeObject<List<Room>>(result);
                listRoom.ForEach(room => RoomItems.Add(room.RoomID));
                listRoom.ForEach(room => AllRooms.Add(room));
                //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
                Console.WriteLine(RoomItems);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
