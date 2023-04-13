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
    public class ReservationViewModel : INotifyPropertyChanged {

        // TODO: 
        //      viewmodel schreiben, mit lists für daten von guests und so, dann die jeweiligen dinge zu der reservation hinzufügen
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime _startDate;
        public DateTime _endDate;
        public Bill _bill;
        public Room _room;
        public Guest _guest;
        public int _billId;
        public int _guestId;
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

        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();
        public ObservableCollection<Guest> Guests { get; set; } = new ObservableCollection<Guest>();
        public ObservableCollection<int> GuestItems { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> BillItems { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> RoomItems { get; set; } = new ObservableCollection<int>();

        public Bill Bill {
            get { return _bill; }
            set {
                if (value != _bill) {
                    _bill = value;
                    OnPropertyChanged();
                }
            }
        }

        public int BillSel {
            get { return _billId; }
            set {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7500");

                var response = client.GetAsync("/api/bill/" + value);
                Console.WriteLine(response);
                if (response != null) {
                    string result = response.ToString();
                    var Bill = JsonConvert.DeserializeObject<Bill>(result);
                    if (Bill != _bill) {
                        _bill = Bill;
                        _billId = value;
                        OnPropertyChanged();
                    }
                    Console.WriteLine(Rooms);
                }
            }
        }

        public int RoomSel {
            get { return _roomId; }
            set {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7500");

                var response = client.GetAsync("/api/room/" + value);
                Console.WriteLine(response);
                if (response != null) {
                    string result = response.ToString();
                    var Room = JsonConvert.DeserializeObject<Room>(result);
                    if (!Rooms.Contains(Room)) {
                        _roomId = value;
                        Rooms.Add(Room);
                        OnPropertyChanged();
                    }
                    Console.WriteLine(Rooms);
                }
                
            }
        }

        public int GuestSel {
            get { return _guestId; }
            set {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7500");

                var response = client.GetAsync("/api/guest/" + value);
                Console.WriteLine(response);
                if (response != null) {
                    string result = response.ToString();
                    var Guest = JsonConvert.DeserializeObject<Guest>(result);
                    if (!Guests.Contains(Guest)) {
                        _guestId = value;
                        Guests.Add(Guest);
                    }
                    Console.WriteLine(Guests);
                }
            }
        }

        public async void OnShowReservation() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7500");
            
            var response = await client.GetAsync("/api/room/rooms");
            Console.WriteLine(response);
            if (response != null) {
                RoomItems.Clear();
                string result = await response.Content.ReadAsStringAsync();
                var listRoom = JsonConvert.DeserializeObject<List<Room>>(result);
                listRoom.ForEach(room => RoomItems.Add(room.RoomID));
                //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
                Console.WriteLine(RoomItems);
            }

            var responseGuest = await client.GetAsync("/api/guest/guests");
            Console.WriteLine(responseGuest);
            if (responseGuest != null) {
                GuestItems.Clear();
                string result = await responseGuest.Content.ReadAsStringAsync();
                var listGuest = JsonConvert.DeserializeObject<List<Guest>>(result);
                listGuest.ForEach(guest => GuestItems.Add(guest.Passnumber));
                //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
                Console.WriteLine(GuestItems);
            }

            var responseBill = await client.GetAsync("/api/bill/bills");
            Console.WriteLine(responseBill);
            if (responseBill != null) {
                BillItems.Clear();
                string result = await responseBill.Content.ReadAsStringAsync();
                var listBill = JsonConvert.DeserializeObject<List<Bill>>(result);
                listBill.ForEach(bill => BillItems.Add(bill.BillId));
                //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
                Console.WriteLine(BillItems);
            }
        }


        public ReservationViewModel() {
            this.CmdReservation = new Command(OnReservation);
        }

        public ICommand CmdReservation { get; private set; }

        private void OnReservation() {

            Reservation reservation = new Reservation() {
                Startdate = this.Startdate,
                Enddate = this.Enddate,
                Bill = this.Bill,
                Rooms = Rooms.ToList(),
                Guests = Guests.ToList()
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7500");

            var response = client.PostAsJsonAsync<Reservation>("/api/reservation/post", reservation);

            Console.WriteLine(response);
        }

        public void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
