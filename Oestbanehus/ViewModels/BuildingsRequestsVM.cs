using Oestbanehus.Models;
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
    class BuildingsRequestsVM : ViewModelBase
    {
        public ObservableCollection<BuildingRequests> Buildings { get; set; }

        private BuildingRequests _selectedBuilding;
        public BuildingRequests selectedBuilding
        {
            get
            {
                return _selectedBuilding;
            }
            set
            {
                Set(ref _selectedBuilding, value);
            }
        }

        private ApartmentWithRequests _selectedApt;
        public ApartmentWithRequests selectedApt
        {
            get
            {
                return _selectedApt;
            }
            set
            {
                Set(ref _selectedApt, value);
            }
        }

        private Request _selectedRequest;
        public Request selectedRequest
        {
            get
            {
                return _selectedRequest;
            }
            set
            {
                Set(ref _selectedRequest, value);
                NavigationService.Navigate(typeof(RequestWithDetails), selectedRequest.Id);
            }
        }

        public BuildingsRequestsVM()
        {
            Buildings = new ObservableCollection<BuildingRequests>();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = await Persistence.Persistence.getBuildingsWithRequests();
            foreach (var item in a)
            {
                Buildings.Add(item);
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
