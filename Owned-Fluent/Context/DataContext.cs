using Microsoft.EntityFrameworkCore;

namespace Owned_Fluent.Context
{
    public class DataContext:DbContext
    {
        public DbSet<Agenda> Agenda { get; set; }

        public DataContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>()
                .OwnsOne(c => c.Comercial);

            modelBuilder.Entity<Agenda>()
               .OwnsOne(c => c.Residencial)
               .ToTable("Comercial");
               
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OwnedEntities;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}