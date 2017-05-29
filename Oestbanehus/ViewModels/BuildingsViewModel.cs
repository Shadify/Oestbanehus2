using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Template10.Services.NavigationService;
using Oestbanehus.Views;
using Newtonsoft.Json.Linq;
using Oestbanehus.Persistence;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Oestbanehus.ViewModels
{
    class BuildingsViewModel : ViewModelBase
    {

        public ObservableCollection<Building> buildings { get; set; }
        public ObservableCollection<Apartment> Apartments { get;set; }

 
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
                ExecuteCommand.Execute(selectedBuilding.Id);
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
                openAptCommand.Execute();
            }
        }


        DelegateCommand _executeCommand;
        public DelegateCommand ExecuteCommand
            => _executeCommand ?? (_executeCommand = new DelegateCommand( () =>
            {
                ApartmentsSingleton.LoadApartmentsInBuildingAsync(selectedBuilding.Id);
                Apartments.Clear();
                foreach (var ap in ApartmentsSingleton.Instance.ObservableCollection)
                {
                    Apartments.Add(ap);
                }
                 
            }, () => true));

        DelegateCommand _openAptCommand;
        public DelegateCommand openAptCommand
            => _openAptCommand ?? (_openAptCommand = new DelegateCommand(() =>
            {
                NavigationService.Navigate(typeof(Views.ApartmentPage), selectedApartment);

            }, () => true));



        public BuildingsViewModel()
        {
            //_loadAptsCommand = new DelegateCommand<int>(loadApts);
            Apartments = new ObservableCollection<Apartment>();
        }


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = BuildingsSingleton.Instance;
            buildings = a.ObservableCollection; 
        }


        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}
