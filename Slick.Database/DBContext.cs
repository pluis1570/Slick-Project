using Microsoft.EntityFrameworkCore;
using Slick.Models.Contact;
using Slick.Models.People;
using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Consultant> Consultants{ get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<ConsultantSpecialisation> ConsultantSpecialisations { get; set; }

    }
}
