using Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotelapp.ViewModels {
    public class RegisterViewModel : INotifyPropertyChanged{

        public event PropertyChangedEventHandler PropertyChanged;

        // Guest - Data
        public string _firstName;
        public string _lastName;
        public DateTime _birthDate;
        public string _email;
        public Gender _gender;

        // Address - Data
        public string _country;
        public int _postalCode;
        public string _city;
        public string _street;
        public int _houseNumber;

        public string Firstname {
            get { return _firstName; }
            set {
                if (value != _firstName) {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Lastname {
            get { return _lastName; }
            set {
                if (value != _lastName) {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Birthdate {
            get { return _birthDate; }
            set {
                if (value != _birthDate) {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EMail {
            get { return _email; }
            set {
                if (value != _email) {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public Gender Gender {
            get { return _gender; }
            set {
                if (value != _gender) {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }

        // Address
        public string Country {
            get { return _country; }
            set {
                if (value != _country) {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }

        public int PostalCode {
            get { return _postalCode; }
            set {
                if (value != _postalCode) {
                    _postalCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string City {
            get { return _city; }
            set {
                if (value != _city) {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Street {
            get { return _street; }
            set {
                if (value != _street) {
                    _street = value;
                    OnPropertyChanged();
                }
            }
        }

        public int HouseNumber {
            get { return _houseNumber; }
            set {
                if (value != _houseNumber) {
                    _houseNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> GenderItems {
            get {
                return Enum.GetNames<Gender>().ToList();
            }
        }

        public RegisterViewModel() {
            this.CmdRegister = new Command(OnRegisterGuest);
        }

        public ICommand CmdRegister { get; private set; }

        private void OnRegisterGuest() {

            Address address = new Address() {
                Country = this.Country,
                PostalCode = this.PostalCode,
                City = this.City,
                Street = this.Street,
                HouseNumber = this.HouseNumber
            };

            Guest guest = new Guest() {
                Firstname = this.Firstname,
                Lastname = this.Lastname,
                Birthdate = this.Birthdate,
                EMail = this.EMail,
                Gender = this.Gender
            };

            guest.Address = address;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7500");

            var response = client.PostAsJsonAsync<Guest>("/api/guest/register", guest);

            Console.WriteLine(response);
        }




        public void OnPropertyChanged([CallerMemberName] string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
