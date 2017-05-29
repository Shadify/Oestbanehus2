using Oestbanehus.Models;
using Oestbanehus.Services;
using Oestbanehus.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.SettingsService;
using Windows.Storage;

namespace Oestbanehus.ViewModels
{
    class ShellVM2 : ViewModelBase, INotifyPropertyChanged
    {


        private int _loggedUserType;
        public int loggedUserType
        {
            get
            {
                return _loggedUserType;
            }
            set
            {
                Set(ref _loggedUserType, value);
            }
        }



        private void OnMessageReceived(string userType)
        {
            loggedUserType = Int32.Parse(userType);
        }

        public ShellVM2()
        {
            Aggregate.OnMessageTransmitted += OnMessageReceived;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                RaisePropertyChanged(propertyName);
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));




        public void GotoSettings() =>
          NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
