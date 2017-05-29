namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Comment
    {
        public int Id { get; set; }

        public int ConditionId { get; set; }

        public int PersonId { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public virtual Person Person { get; set; }
    }
}
