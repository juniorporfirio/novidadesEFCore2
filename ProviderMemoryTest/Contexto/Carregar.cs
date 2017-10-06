using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProviderMemoryWebAPI.Contexto;
using ProviderMemoryWebAPI.Entidades;

namespace ProviderMemoryTest.Contexto
{
    public static class Carregar
    {

        public static ContextoAPI DadosMemoria()
        {
            var options = new DbContextOptionsBuilder<ContextoAPI>()
                .UseInMemoryDatabase(Guid
                .NewGuid().ToString()).Options;

            var contexto = new ContextoAPI(options);


            contexto.Pessoas.AddRange(new List<Pessoa>()
            {
                //pt-BR
                new Pessoa(){ID = Guid.NewGuid(), Pais = "pt-BR", Nome = "Junior Porfirio", Excluido = false, WebSite = @"https://medium.com/@juniorporfirio"},
                new Pessoa(){ID = Guid.NewGuid(), Pais = "pt-BR", Nome = "Renato Groffe", Excluido = false, WebSite = @"https://medium.com/@renato.groffe"},
                new Pessoa(){ID = Guid.NewGuid(), Pais = "pt-BR", Nome = "Rodolfo Fadino", Excluido = false, WebSite = @"https://rodolfofadino.com.br/"},
                //en-US
                new Pessoa(){ID = Guid.NewGuid(), Pais = "en-US",  Nome = "Scott Hanselman", Excluido = false, WebSite = @"https://www.hanselman.com/"},
                new Pessoa(){ID = Guid.NewGuid(), Pais = "en-US",  Nome = "Greg Shackles", Excluido = false, WebSite = @"https://gregshackles.com/"}
            });

            contexto.SaveChanges();

            return contexto;



        }
    }
}