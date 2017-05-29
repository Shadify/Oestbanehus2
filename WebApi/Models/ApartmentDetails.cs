using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [NotMapped]
    public class ApartmentDetails
    {

        public int Id { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int NumberOfRooms { get; set; }

        public int Floor { get; set; }

        public string ApartmentNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public IEnumerable<Person> Residents { get; set; }

    }
}