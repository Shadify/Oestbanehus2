using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [NotMapped]
    public class ApartmentWithRequests
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int NumberOfRooms { get; set; }

        public int Floor { get; set; }

        public string ApartmentNumber { get; set; }

        public string Street { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}