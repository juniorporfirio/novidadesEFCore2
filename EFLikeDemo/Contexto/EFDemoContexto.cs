using EFLikeDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFLikeDemo.Contexto
{
    public class EFDemoContexto:DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public EFDemoContexto(DbContextOptions<EFDemoContexto> options):base(options)
        {

        }
    }
}