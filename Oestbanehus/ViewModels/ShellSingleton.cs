using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace Oestbanehus.ViewModels
{
    class ShellSingleton : ViewModelBase
    {
        private ShellSingleton()
        {
            // constructor
            loggedUserType = -1;
        }
        private static ShellSingleton sInstance;
        public static ShellSingleton Instance => sInstance ?? (sInstance = new ShellSingleton());

        public int loggedUserType { get; set; }
    }
}
