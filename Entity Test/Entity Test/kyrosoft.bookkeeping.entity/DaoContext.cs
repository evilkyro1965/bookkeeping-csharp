using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace kyrosoft.bookkeeping.entity
{
    class DaoContext:DbContext
    {
        public DaoContext() : base(nameOrConnectionString: "bookkeeping") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOptional<User>(c => c.user)
                .WithOptionalDependent() 
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<Client>()
                .HasOptional<Country>(c => c.country)
                .WithOptionalDependent()
                .Map(m => m.MapKey("countryId"));

        }
    }
}
