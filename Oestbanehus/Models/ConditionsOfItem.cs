namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ConditionsOfItem
    {

        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public int ConditionType { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public string Status { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
