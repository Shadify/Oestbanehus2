using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    namespace WebApi.Models
    {
        [NotMapped]
        public class BuildingRequests
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
}