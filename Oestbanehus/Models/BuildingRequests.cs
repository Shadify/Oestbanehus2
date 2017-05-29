using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oestbanehus.Models;

namespace Oestbanehus.Models
{
    class BuildingRequests
    {
        public BuildingRequests()
        {
            Apartments = new ObservableCollection<ApartmentWithRequests>();
        }


        public int Id { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public ObservableCollection<ApartmentWithRequests> Apartments { get; set; }

        public string City { get; set; }
    }
}
