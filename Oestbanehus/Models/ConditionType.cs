namespace Oestbanehus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ConditionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"TypeId: {Id}\nTypeName: {Name}";
        }
    }
}
