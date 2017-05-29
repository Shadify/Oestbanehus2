using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oestbanehus.Models
{
    class PersonWithDetails
    {
        public Apartment apartment { get; set; }

        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public string MoveInDate { get; set; }

        public string MoveOutDate { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public int Type { get; set; }

        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
