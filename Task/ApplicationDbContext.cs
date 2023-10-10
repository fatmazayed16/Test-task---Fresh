using System;
using System.Data.Entity;

namespace TestTask
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=Model") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                        .HasKey(e => e.Id)
                        .HasMany(e => e.Items).WithRequired(e => e.Invoice).HasForeignKey(e => e.InvoiceId);

            modelBuilder.Entity<Items>()
                        .HasKey(e => e.Id);
        }
    }
}