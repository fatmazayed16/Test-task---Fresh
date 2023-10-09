using System;
using System.Data.Entity;

namespace Test_Task
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=Model") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                        .HasKey(e => e.Id)
                        .HasMany(e => e.Item).WithRequired(e => e.Bill).HasForeignKey(e => e.BillId);

            modelBuilder.Entity<Item>()
                        .HasKey(e => e.Id);
        }
    }
}