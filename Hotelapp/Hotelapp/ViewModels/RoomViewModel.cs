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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotelapp.ViewModels {
    public class RoomViewModel : INotifyPropertyChanged{

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Room> RoomsList { get; set; } = new ObservableCollection<Room>();

        public async void OnShowRooms() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7500");
            //var response = client.GetFromJsonAsync<List<Room>>("/api/room/rooms");
            var response = await client.GetAsync("/api/room/rooms");
            Console.WriteLine(response);
            if(response != null) {
                RoomsList.Clear();
                string result = await response.Content.ReadAsStringAsync();
                var listRoom = JsonConvert.DeserializeObject<List<Room>>(result);
                listRoom.ForEach(room => RoomsList.Add(room));
                //RoomsList = JsonSerializer.Deserialize<List<Room>>(response);
                Console.WriteLine(RoomsList);
            }
            
            /*
            foreach(Room room in response) {
                
                Room u = new Room() {
                    RoomID = room.RoomID,
                    BedCount = room.BedCount,
                    HasBalcony = room.HasBalcony,
                    HasKitchen = room.HasKitchen,
                    HasTerrace = room.HasTerrace,
                    PricePerNight = room.PricePerNight,
                };
                help.Add(u);
            }
            */


        }




        public void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
