using System;
using System.Collections.Generic;
using System.Linq;
using Oestbanehus.Models;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Oestbanehus.Views.Board;

namespace Oestbanehus.ViewModels
{
    class RequestViewModel : ViewModelBase
    {

        public ObservableCollection<Request> Requests { get; set; }

        public RequestViewModel()
        {
            Requests = new ObservableCollection<Request>();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var b = await Persistence.Persistence.getRequestsOfApartment((int)parameter);
            foreach (var c in b)
            {
                Requests.Add(c);
            }

            currentApartmentId = (int)parameter;
        }

        DelegateCommand _navToAddReq;
        public DelegateCommand navToAddReq
            => _navToAddReq ?? (_navToAddReq = new DelegateCommand(() =>
            {

                NavigationService.Navigate(typeof(AddRequest), currentApartmentId);

            }, () => true));


        private int _currentApartmentId;
        public int currentApartmentId
        {
            get
            {
                return _currentApartmentId;
            }
            set
            {
                Set(ref _currentApartmentId, value);

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
