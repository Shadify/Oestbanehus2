namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class City
    {

        public string ZipCode { get; set; }

        public string CityName { get; set; }

    }
}
