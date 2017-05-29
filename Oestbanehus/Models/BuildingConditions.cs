using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oestbanehus.Models
{
    public class BuildingConditions
    {
        public BuildingConditions()
        {
            Apartments = new ObservableCollection<ApartmentWithConditions>();
        }


        public int Id { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public ObservableCollection<ApartmentWithConditions> Apartments { get; set; }

        public string City { get; set; }

    }
}
