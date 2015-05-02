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
        public DbSet<TaxCategory> TaxCategories { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }

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

            modelBuilder.Entity<Client>()
                .HasMany<ClientContact>(client => client.contacts)
                .WithRequired(contact => contact.client)
                .HasForeignKey(contact => contact.clientId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TaxCategory>()
                .HasOptional<User>(t => t.user)
                .WithOptionalDependent()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<IncomeCategory>()
                .HasOptional<User>(i => i.user)
                .WithOptionalDependent()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<IncomeCategory>()
                .HasOptional<TaxCategory>(i => i.taxCategory)
                .WithOptionalDependent()
                .Map(m => m.MapKey("taxCategoryId"));

            modelBuilder.Entity<ExpenseCategory>()
                .HasOptional<User>(e => e.user)
                .WithOptionalDependent()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<ExpenseCategory>()
                .HasOptional<TaxCategory>(e => e.taxCategory)
                .WithOptionalDependent()
                .Map(m => m.MapKey("taxCategoryId"));

            modelBuilder.Entity<Income>()
                .HasOptional<IncomeCategory>(i => i.incomeCategory)
                .WithOptionalDependent()
                .Map(m => m.MapKey("incomeCategoryId"));

            modelBuilder.Entity<Income>()
                .HasOptional<User>(e => e.user)
                .WithOptionalDependent()
                .Map(m => m.MapKey("userId"));

            modelBuilder.Entity<Expense>()
                .HasOptional<ExpenseCategory>(e => e.expenseCategory)
                .WithOptionalDependent()
                .Map(m => m.MapKey("expenseCategoryId"));

            modelBuilder.Entity<Expense>()
                .HasOptional<User>(e => e.user)
                .WithOptionalDependent()
                .Map(m => m.MapKey("userId"));

        }
    }
}
