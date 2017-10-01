using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using GlobalQueryFilter.Context;
using GlobalQueryFilter.Entity;


namespace GlobalQueryFilter
{
   public class Program
    {

        static void Main(string[] args)
        {
            //Definindo a cultura de pessoas para filter;

            var culture = CultureInfo.CreateSpecificCulture("pt-BR");

            //Define a culture em uma Thead
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            //Carrega os dados para o Banco de Dados
            LoadDatabase();

            //Exibe os resultados filtrados por País
            ResultDatabase();

            Console.ReadKey();
        }
        /// <summary>
        /// Método que salva registros no banco de dados
        /// </summary>
        static void LoadDatabase()
        {
            using (var context = new GlobalFilterDbContext())
            {
                if (context.Pessoas.Any()) return;

                context.Pessoas.AddRange(new List<Pessoa>()
                {
                    //pt-BR
                    new Pessoa(){ID = Guid.NewGuid(), Pais = "pt-BR", Nome = "Junior Porfirio", Excluido = false, WebSite = @"https://medium.com/@juniorporfirio"},
                    new Pessoa(){ID = Guid.NewGuid(), Pais = "pt-BR", Nome = "Renato Groffe", Excluido = false, WebSite = @"https://medium.com/@renato.groffe"},
                    new Pessoa(){ID = Guid.NewGuid(), Pais = "pt-BR", Nome = "Rodolfo Fadino", Excluido = false, WebSite = @"https://rodolfofadino.com.br/"},
                    //en-US
                    new Pessoa(){ID = Guid.NewGuid(), Pais = "en-US",  Nome = "Scott Hanselman", Excluido = false, WebSite = @"https://www.hanselman.com/"},
                    new Pessoa(){ID = Guid.NewGuid(), Pais = "en-US",  Nome = "Greg Shackles", Excluido = false, WebSite = @"https://gregshackles.com/"}
                });

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método que retorna Todos os dados das Pessoas
        /// </summary>
        static void ResultDatabase()
        {
            using (var context = new GlobalFilterDbContext())
            {
                var pessoas = context.Pessoas.ToList();

                foreach (var pessoa in pessoas)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine(pessoa.ToString());
                    Console.WriteLine("---------------------------------------------");
                }
            }

        }
    }
}
