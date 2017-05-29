namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json.Linq;

    public partial class Building
    {

        public int Id { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return $"Zip: {ZipCode}\nStreet: {Street}";
        }

    }
}
