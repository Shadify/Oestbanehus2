﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Oestbanehus4Entities : DbContext
    {
        public Oestbanehus4Entities()
            : base("name=Oestbanehus4Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ConditionsOfItem> ConditionsOfItems { get; set; }
        public virtual DbSet<ConditionType> ConditionTypes { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
    }
}
