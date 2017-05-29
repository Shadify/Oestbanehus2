namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Person
    {

        public int Id { get; set; }

        public int ApartmentId { get; set; }
     
        public string MoveInDate { get; set; }

        public string MoveOutDate { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Picture { get; set; }

        public int Type { get; set; }
    }
}
