using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oestbanehus.Models
{
    class ApartmentDetails : Apartment
    {
      
        public string City { get; set; }

        public string ZipCode { get; set; }

        public IEnumerable<Person> Residents { get; set; }
    }
}
