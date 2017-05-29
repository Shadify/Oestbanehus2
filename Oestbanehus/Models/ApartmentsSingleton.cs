using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Oestbanehus.Models
{
    class ApartmentsSingleton : INotifyPropertyChanged
    {
        private static ApartmentsSingleton instance;

        private static ObservableCollection<Apartment> _observableCollection;

        public ObservableCollection<Apartment> ObservableCollection
        {
            get { return _observableCollection; }
            set
            {
                _observableCollection = value;
                OnPropertyChanged(nameof(ObservableCollection));
            }
        }


        public static ApartmentsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApartmentsSingleton();
                }
                return instance;
            }
        }

        //ALL APARTMENTS
        public async void LoadApartmentsAsync()
        {
            _observableCollection = await Persistence.Persistence.getApartmentsAsync();
        }

        //APARTMENTS IN A BUILDING
        public static async void LoadApartmentsInBuildingAsync(int buildingId)
        {
            _observableCollection = await Persistence.Persistence.getApartmentsInBuilding(buildingId);
        }






        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
