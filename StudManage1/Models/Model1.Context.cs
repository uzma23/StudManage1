//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudManage1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentManagement1Entities : DbContext
    {
        public StudentManagement1Entities()
            : base("name=StudentManagement1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<branch> branches { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<eduDetail> eduDetails { get; set; }
        public virtual DbSet<result> results { get; set; }
        public virtual DbSet<roll> rolls { get; set; }
        public virtual DbSet<signup> signups { get; set; }
        public virtual DbSet<stuDetail> stuDetails { get; set; }
        public virtual DbSet<userrollmap> userrollmaps { get; set; }
    }
}
