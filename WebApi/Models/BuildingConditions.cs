using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [NotMapped]
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