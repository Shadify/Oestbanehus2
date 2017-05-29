namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Apartment
    {

        public int Id { get; set; }

        public int BuildingId { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int NumberOfRooms { get; set; }

        public int Floor { get; set; }

        public string ApartmentNumber { get; set; }

        public string Street { get; set; }

        public override string ToString()
        {
            return $"Street: {Street}\nApartment Number: {ApartmentNumber}\nFloor: {Floor}";
        }

    }
}
