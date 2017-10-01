using System;
using System.Threading;
using GlobalQueryFilter.Entity;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilter.Context
{
    public class GlobalFilterDbContext:DbContext
    {

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Recupera o pais da aplicação
            var culturecountry = Thread.CurrentThread.CurrentUICulture.ToString();

            //Realiza o filtro da entidade cliente
            modelBuilder.Entity<Pessoa>().HasQueryFilter(c => c.Pais.Equals(culturecountry) && !c.Excluido);

           
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=NovidadesEFCore2;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}