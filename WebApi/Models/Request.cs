namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int ApartmentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public string Picture { get; set; }

        public virtual Apartment Apartment { get; set; }

        public virtual Person Person { get; set; }
    }
}
