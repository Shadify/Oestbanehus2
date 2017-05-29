namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ConditionId { get; set; }

        public int PersonId { get; set; }

        [Required]
        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime PublishedDate { get; set; }

        public virtual ConditionsOfItem ConditionsOfItem { get; set; }

        public virtual Person Person { get; set; }
    }
}
