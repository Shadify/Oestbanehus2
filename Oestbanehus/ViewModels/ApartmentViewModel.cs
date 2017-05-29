using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace Oestbanehus.ViewModels
{
    class ApartmentViewModel : ViewModelBase
    {
        private ApartmentDetails _apartment;
        public ApartmentDetails apartment
        {
            get
            {
                return _apartment;
            }
            set
            {
                Set(ref _apartment, value);

            }
        }

        DelegateCommand _toConditions;
        public DelegateCommand toConditions
            => _toConditions ?? (_toConditions = new DelegateCommand(() =>
            {
                if (apartment != null)
                {
                    NavigationService.Navigate(typeof(Views.Conditions), apartment.Id);
                }
            }, () => true));

        DelegateCommand _toRequests;
        public DelegateCommand toRequests
            => _toRequests ?? (_toRequests = new DelegateCommand(() =>
            {
                if(apartment != null)
                {
                    NavigationService.Navigate(typeof(Views.Requests), apartment.Id);
                }
            }, () => true));


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var b = parameter.GetType();
                var c = new Apartment();
            if(b == c.GetType())
            {
                var Dapartment = (Apartment)parameter;
                apartment = await Persistence.Persistence.getApartmentDetails(Dapartment.Id);
                var a = apartment;
            } else
            {
                apartment = await Persistence.Persistence.getApartmentDetails((int)parameter);
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
