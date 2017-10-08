using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProviderMemoryWebAPI.Contexto;
using ProviderMemoryWebAPI.Entidades;
// ReSharper disable InconsistentNaming

namespace ProviderMemoryWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/pessoas")]
    public class PessoaController : Controller
    {
        private readonly ContextoAPI _contexto;

        public PessoaController(ContextoAPI contexto)
        {
            _contexto = contexto;

        }


        [HttpGet("comPaisPtBR")]
        public ICollection<Pessoa> comPaisPtBR()
        {

            var pessoas = _contexto.Pessoas.AsNoTracking().Where(c => c.Pais.Equals("pt-BR"));

            return pessoas.ToList();
        }

        [HttpGet]
        [Route("comNome/{nome}")]
        public Pessoa porNome(string nome)
        {
            var pessoas = _contexto.Pessoas.AsNoTracking().FirstOrDefault(c=>c.Nome.Contains(nome));

            return pessoas;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
                _contexto.Dispose();

            base.Dispose(disposing);
        }
    }
}