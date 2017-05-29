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
    class ConditionTypeSingleton : INotifyPropertyChanged
    {
        private static ConditionTypeSingleton instance;
        private static ObservableCollection<ConditionType> _observableCollection;

        public ObservableCollection<ConditionType> ObservableCollection
        {
            get { return _observableCollection; }
            set
            {
                _observableCollection = value;
                    OnPropertyChanged(nameof(ObservableCollection));
            }
        }

        public static ConditionTypeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConditionTypeSingleton();
                }
                return instance;
            }
        }

        //Load conditiontypes
        public async void LoadConditionTypes()
        {
            _observableCollection = await Persistence.Persistence.getConditionTypesAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
