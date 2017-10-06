using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProviderMemoryWebAPI.Contexto;
using ProviderMemoryWebAPI.Entidades;

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

        [HttpGet]
        [Route("v1/ptBR")]
        public ICollection<Pessoa> ComPaisptBR()
        {

            var pessoas = _contexto.Pessoas.AsNoTracking().Where(c => c.Pais.Equals("pt-BR"));

            return pessoas.ToList();
        }

        [HttpGet]
        [Route("v1/nome/{nome}")]
        public Pessoa PorNome(string nome)
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