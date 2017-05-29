using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oestbanehus.Models
{
    class ApartmentWithRequests
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int NumberOfRooms { get; set; }

        public int Floor { get; set; }

        public string ApartmentNumber { get; set; }

        public string Street { get; set; }

        public List<Request> Requests { get; set; }
    }
}
