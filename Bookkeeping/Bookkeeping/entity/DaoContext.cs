using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace kyrosoft.bookkeeping.entity
{
    public class DaoContext : DbContext
    {
        public DaoContext() : base(nameOrConnectionString: "bookkeeping") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<TaxCategory> TaxCategories { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOptional<User>(c => c.user)
                .WithMany()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<Client>()
                .HasOptional<Country>(c => c.country)
                .WithMany()
                .Map(m => m.MapKey("countryId"));

            modelBuilder.Entity<Client>()
                .HasMany<ClientContact>(client => client.contacts)
                .WithRequired(contact => contact.client)
                .HasForeignKey(contact => contact.clientId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TaxCategory>()
                .HasRequired<User>(t => t.user)
                .WithMany()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<IncomeCategory>()
                .HasRequired<User>(i => i.user)
                .WithMany()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<IncomeCategory>()
                .HasRequired<TaxCategory>(i => i.taxCategory)
                .WithMany()
                .Map(m => m.MapKey("taxCategoryId"));

            modelBuilder.Entity<ExpenseCategory>()
                .HasRequired<User>(e => e.user)
                .WithMany()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<ExpenseCategory>()
                .HasRequired<TaxCategory>(e => e.taxCategory)
                .WithMany()
                .Map(m => m.MapKey("taxCategoryId"));

            modelBuilder.Entity<Income>()
                .HasRequired<IncomeCategory>(i => i.incomeCategory)
                .WithMany()
                .Map(m => m.MapKey("incomeCategoryId"));

            modelBuilder.Entity<Income>()
                .HasRequired<User>(i => i.user)
                .WithMany()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<Expense>()
                .HasRequired<ExpenseCategory>(e => e.expenseCategory)
                .WithMany()
                .Map(m => m.MapKey("expenseCategoryId"));

            modelBuilder.Entity<Expense>()
                .HasRequired<User>(e => e.user)
                .WithMany()
                .Map(m => m.MapKey("userId"));

        }
    }
}
