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
    class BuildingsSingleton : INotifyPropertyChanged
    {
        private static BuildingsSingleton instance;

        private ObservableCollection<Building> _observableCollection;

        public ObservableCollection<Building> ObservableCollection
        {
            get { return _observableCollection; }
            set
            {
                _observableCollection = value;
                OnPropertyChanged(nameof(ObservableCollection));
            }
        }


        private BuildingsSingleton() {
            LoadBuildingsAsync();
        }

        public static BuildingsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuildingsSingleton();
                }
                return instance;
            }
        }

        public async void LoadBuildingsAsync()
        {
            _observableCollection = await Persistence.Persistence.getBuildingsAsync();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
