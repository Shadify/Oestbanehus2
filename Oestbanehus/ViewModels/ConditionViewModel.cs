using System;
using System.Collections.Generic;
using System.Linq;
using Oestbanehus.Models;
using Oestbanehus.Views;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace Oestbanehus.ViewModels
{
    class ConditionViewModel : ViewModelBase
    {

        public ObservableCollection<ConditionsOfItem> Conditions { get; set; }

        private ConditionsOfItem _selectedCondition;
        public ConditionsOfItem selectedCondition
        {
            get
            {
                return _selectedCondition;
            }
            set
            {
                Set(ref _selectedCondition, value);
                NavigationService.Navigate(typeof(ConditionDetail), selectedCondition.Id);
            }
        }

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

        DelegateCommand _navToAddCondition;
        public DelegateCommand navToAddCondition
            => _navToAddCondition ?? (_navToAddCondition = new DelegateCommand(() =>
            {
                NavigationService.Navigate(typeof(Views.Board.AddCondition), apartmentId);

            }, () => true));

        public ConditionViewModel()
        {
            Conditions = new ObservableCollection<ConditionsOfItem>();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            apartmentId = (int)parameter;
           var b = await Persistence.Persistence.getConditionsOfApartment((int)parameter);
            foreach (var c in b)
            {
                Conditions.Add(c);
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
