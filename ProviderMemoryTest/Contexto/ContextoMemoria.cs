using Microsoft.EntityFrameworkCore;
using ProviderMemoryWebAPI.Entidades;

namespace ProviderMemoryTest.Contexto
{
    public class ContextoMemoria:DbContext
    {
       
        public DbSet<Pessoa> Pessoas { get; set; }
        public ContextoMemoria(DbContextOptions<ContextoMemoria> options) : base(options)
        {
        }
    }
}