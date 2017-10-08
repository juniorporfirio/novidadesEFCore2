using Microsoft.EntityFrameworkCore;
using ProviderMemoryWebAPI.Entidades;
// ReSharper disable InconsistentNaming

namespace ProviderMemoryWebAPI.Contexto
{
    public class ContextoAPI:DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public ContextoAPI(DbContextOptions<ContextoAPI> options):base(options)
        {
            
        }
    }
}
