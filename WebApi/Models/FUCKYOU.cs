using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public partial class FUCKYOU
    {
       
        public int Id { get; set; }

        public int ApartmentId { get; set; }

        public int ConditionType { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public string Status { get; set; }

        public  IEnumerable<Comment> Comments { get; set; }

    }
}