using Oestbanehus.Models;
using Oestbanehus.Views.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Oestbanehus.ViewModels
{
    class ViewModelRequestDetails: ViewModelBase
    {
        private Request _request;
        public Request request
        {
            get
            {
                return _request;
            }
            set
            {
                Set(ref _request, value);
            }
        }

        public ViewModelRequestDetails()
        {
            
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            request = await Persistence.Persistence.getRequestDetails((int)parameter);
        }



        public void GotoSettings() =>
           NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
