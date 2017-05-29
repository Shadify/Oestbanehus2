using Oestbanehus.Models;
using Oestbanehus.Views;
using Oestbanehus.Views.Board;
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
    class ResidentViewModel : ViewModelBase
    {
        public ObservableCollection<Person> Residents { get; set; }


        private Person _selectedResident;
        public Person selectedResident
        {
            get
            {
                return _selectedResident;
            }
            set
            {
                Set(ref _selectedResident, value);
                getDetails(selectedResident.Id);

            }
        }

        private PersonWithDetails _pwd;
        public PersonWithDetails pwd
        {
            get
            {
                return _pwd;
            }
            set
            {
                Set(ref _pwd, value);
            }
        }

        public ResidentViewModel()
        {
            Residents = new ObservableCollection<Person>();
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = await Persistence.Persistence.getAllResidents();
            foreach (var r in a)
            {
                Residents.Add(r);
            }
        }

        DelegateCommand _navToAddPerson;
        public DelegateCommand navToAddPerson
            => _navToAddPerson ?? (_navToAddPerson = new DelegateCommand(() =>
            {
                NavigationService.Navigate(typeof(AddPerson));

            }, () => true));

        public async void getDetails(int id)
        {
            pwd = await Persistence.Persistence.getPersonWithDetails(id);
        }

        public void GotoSettings() =>
          NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
