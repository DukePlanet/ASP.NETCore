using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
  public  class EnrollContext : DbContext
    {


       public EnrollContext(DbContextOptions<EnrollContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DINAR;Database=EnrollContextDB;User Id=sa;Password=Dnr11111111;Trusted_Connection=True;");
            }
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Enroll> Enroll { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        
    }
}
