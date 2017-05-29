using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Storage;

namespace Oestbanehus.Models
{
    public class AppSettings : BindableBase
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public int loggedUserType
        {
            get
            {
                if (!localSettings.Values.ContainsKey("loggedUserType"))
                    localSettings.Values["loggedUserType"] = -1;

                return (int)localSettings.Values["loggedUserType"];
            }
            set
            {
                if (loggedUserType != value)
                {
                    localSettings.Values["loggedUserType"] = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
