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
    class BuildingsConditionsVM : ViewModelBase
    {
        public ObservableCollection<BuildingConditions> Buildings { get; set; }

        private BuildingConditions _selectedBuilding;
        public BuildingConditions selectedBuilding
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

        private ApartmentWithConditions _selectedApt;
        public ApartmentWithConditions selectedApt
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

        public BuildingsConditionsVM()
        {
            Buildings = new ObservableCollection<BuildingConditions>();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = await Persistence.Persistence.getBuildingsWithConditions();
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
