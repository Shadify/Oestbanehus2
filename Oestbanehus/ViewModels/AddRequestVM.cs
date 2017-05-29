using Oestbanehus.Models;
using Oestbanehus.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Oestbanehus.ViewModels
{
    class AddRequestVM : ViewModelBase
    {

        private int _apartmentId;
        public int apartmentId
        {
            get
            {
                return _apartmentId;
            }
            set
            {
                Set(ref _apartmentId, value);

            }
        }

        private string _title;
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                Set(ref _title, value);

            }
        }

        private string _description;
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                Set(ref _description, value);

            }
        }

        DelegateCommand _addRequest;
        public DelegateCommand addRequest
            => _addRequest ?? (_addRequest = new DelegateCommand(() =>
            {
                var newRequest = new Request()
                {
                    ApartmentId = apartmentId,
                    Title = title,
                    Description = description,
                    Date = DateTime.Now,
                    Picture = "lalalla"      
                };

                NavigationService.Navigate(typeof(ApartmentPage), apartmentId);
                Persistence.Persistence.addRequest(newRequest);

            }, () => true));

        public AddRequestVM()
        {

        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            apartmentId = (int)parameter;
        }

        public void GotoSettings() =>
           NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
