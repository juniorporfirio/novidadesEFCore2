using System.Linq;
using ProviderMemoryTest.Contexto;
using ProviderMemoryWebAPI.Controllers;
using Xunit;

namespace ProviderMemoryTest.Testes
{
    public class PessoaTest
    {
        
        [Fact(DisplayName = "Deve retornar uma pessoa com País igual a pt-BR")]
        public void deve_retornar_uma_pessoa_com_pais_igual_pt_BR()
        {
            bool any;

            using (var contexto = Carregar.DadosMemoria())
            using (var api = new PessoaController(contexto))
            {
                var pessoas = api.ComPaisptBR();
                any = pessoas.Any();
            }
            Assert.True(any);

        }

       
        [Theory(DisplayName = "Deve retornar  a pessoa pelo nome")]
        [InlineData("Junior")]
        public void deve_retornar_a_pessoa_pelo_nome(string nome)
        {
          

            using (var contexto = Carregar.DadosMemoria())
            using (var api = new PessoaController(contexto))
            {
                var pessoa = api.PorNome(nome);
                Assert.NotNull(pessoa);
                Assert.NotEmpty(pessoa.Nome);
            }
        }

    }
}