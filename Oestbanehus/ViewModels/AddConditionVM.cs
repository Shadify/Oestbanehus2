using Oestbanehus.Models;
using Oestbanehus.Views;
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
    class AddConditionVM : ViewModelBase
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

        private int _conditionType;
        public int conditionType
        {
            get
            {
                return _conditionType;
            }
            set
            {
                Set(ref _conditionType, value);

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


        DelegateCommand _addCondition;
        public DelegateCommand addCondition
            => _addCondition ?? (_addCondition = new DelegateCommand(() =>
            {
                var newCondition = new ConditionsOfItem();
                newCondition.ApartmentId = apartmentId;
                newCondition.ConditionType = conditionType + 1;
                newCondition.Description = description;
                newCondition.Status = "Pending";
                newCondition.Picture = "adsadsad";

                NavigationService.Navigate(typeof(ApartmentPage), apartmentId);
                Persistence.Persistence.addCondition(newCondition);

            }, () => true));

        public AddConditionVM()
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
