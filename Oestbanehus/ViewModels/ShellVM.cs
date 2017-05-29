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
    class ShellVM: ViewModelBase, INotifyPropertyChanged
    {

        public void SendMessage(string userType)
        {
            Aggregate.BroadCast(userType);
        }


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
                SendMessage(value.ToString());
            }
        }


        public ShellVM()
        {
            
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

        
        private string _error;
        public string error
        {
            get
            {
                return _error;
            }
            set
            {
                Set(ref _error, value);

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



        DelegateCommand _login;
        public DelegateCommand login
            => _login ?? (_login = new DelegateCommand(() =>
            {
                loginnavigation(email, password);
            }, () => true));


        public async void loginnavigation(string email,string password)
        {
            var p = new Person();
            p.Email = email;
            p.Password = password;
            var a = await Persistence.Persistence.Login(p);
            if (a != null)
            {
                loggedUserType = a.Type;
                switch (loggedUserType)
                {
                    case 0:
                        {
                            NavigationService.Navigate(typeof(Buildings));
                            break;
                        }
                    case 1:
                        {
                            NavigationService.Navigate(typeof(BuildingsWithConditions));
                            break;
                        }
                    case 2:
                        {
                            NavigationService.Navigate(typeof(ApartmentPage), a.ApartmentId);
                            break;
                        }
                    default:
                        break;
                }
            } else
            {
                error = "Wrong email or password";
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
