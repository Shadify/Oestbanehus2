using Oestbanehus.Models;
using Oestbanehus.Services;
using Oestbanehus.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Oestbanehus.ViewModels
{
    class AddPersonVM : ViewModelBase
    {
        private Person _newPerson;
        public Person newPerson
        {
            get
            {
                return _newPerson;
            }
            set
            {
                Set(ref _newPerson, value);

            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(ref _name, value);

            }
        }

        private string _email;
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                Set(ref _email, value);

            }
        }

        private string _password;
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);

            }
        }


        private string _phone;
        public string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                Set(ref _phone, value);

            }
        }


        private int _type;
        public int type
        {
            get
            {
                return _type;
            }
            set
            {
                Set(ref _type, value);

            }
        }

        private Building _selectedBuilding;
        public Building selectedBuilding
        {
            get
            {
                return _selectedBuilding;
            }
            set
            {
                Set(ref _selectedBuilding, value);
                assignApt(selectedBuilding.Id);
            }
        }

        private Apartment _selectedApartment;
        public Apartment selectedApartment
        {
            get
            {
                return _selectedApartment;
            }
            set
            {
                Set(ref _selectedApartment, value);
            }
        }
        
        private DateTimeOffset _movein;
        public DateTimeOffset movein
        {
            get
            {
                return _movein;
            }
            set
            {
                Set(ref _movein, value);
            }
        }

        public ObservableCollection<Building> buildings { get; set; }
        public ObservableCollection<Apartment> apartments { get; set; }



        public AddPersonVM()
        {
            newPerson = new Person() { Type=1 };
            buildings = new ObservableCollection<Building>();
            apartments = new ObservableCollection<Apartment>();

        }


        DelegateCommand _sendPost;
        public DelegateCommand sendPost
            => _sendPost ?? (_sendPost = new DelegateCommand(() =>
            {
                newPerson.Name = name;
                newPerson.Phone = phone;
                newPerson.Email = email;
                newPerson.Type = type;
                newPerson.Password = password;
                if (newPerson.Type != 2)
                {
                    newPerson.ApartmentId = 1000;
                    Persistence.Persistence.addPerson(newPerson);
                    NavigationService.Navigate(typeof(Residents));
                } else
                {
                    newPerson.ApartmentId = selectedApartment.Id;
                    newPerson.MoveInDate = movein.DateTime.ToString();
                    Persistence.Persistence.addPerson(newPerson);
                    NavigationService.Navigate(typeof(Residents));
                }
               
            }, () => true));


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = await Persistence.Persistence.getBuildingsAsync();
            foreach (var item in a)
            {
                buildings.Add(item);
            }
        }

        public async void assignApt(int id)
        {
            var a = await Persistence.Persistence.getApartmentsInBuilding(id);
            foreach (var item in a)
            {
                apartments.Add(item);
            }
        }

        public void GotoSettings() =>
         NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
