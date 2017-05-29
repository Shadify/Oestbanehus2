using System.ComponentModel;
using System.Linq;
using System;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Template10.Mvvm;
using Oestbanehus.Services;

namespace Oestbanehus.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;
        Services.SettingsServices.SettingsService _settings;

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            _settings = Services.SettingsServices.SettingsService.Instance;
            Aggregate.OnMessageTransmitted += OnMessageReceived;
            Buildings.Visibility = Visibility.Collapsed;
            Residents.Visibility = Visibility.Collapsed;
            Conditions.Visibility = Visibility.Collapsed;
            Requests.Visibility = Visibility.Collapsed;
            Apartment.Visibility = Visibility.Collapsed;
        }

        private void OnMessageReceived(string userType)
        {
            switch (Int32.Parse(userType))
            {
                case 0:
                    {
                        Buildings.Visibility = Visibility.Visible;
                        Residents.Visibility = Visibility.Visible;
                        Conditions.Visibility = Visibility.Visible;
                        Requests.Visibility = Visibility.Visible;
                        
                        break;
                    }
                case 1:
                    {
                        Conditions.Visibility = Visibility.Visible;
                        break;
                    }
                case 2:
                    {
                        Apartment.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    break;
            }
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
            HamburgerMenu.RefreshStyles(_settings.AppTheme, true);
            HamburgerMenu.IsFullScreen = _settings.IsFullScreen;
            HamburgerMenu.HamburgerButtonVisibility = _settings.ShowHamburgerButton ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

