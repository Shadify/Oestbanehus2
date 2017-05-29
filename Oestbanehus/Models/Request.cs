namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Request
    {

        public int Id { get; set; }

        public string Author { get; set; }

        public int ApartmentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Picture { get; set; }

        public Person Person { get; set; }


    }
}
