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
            bool existe;

            using (var contexto = Carregar.DadosMemoria())
            using (var pessoa = new PessoaController(contexto))
            {
                var pessoaPTBR = pessoa.comPaisPtBR();
                existe = pessoaPTBR.Any();
            }
            Assert.True(existe);

        }

       
        [Theory(DisplayName = "Deve retornar  a pessoa pelo nome")]
        [InlineData("Junior")]
        public void deve_retornar_a_pessoa_pelo_nome(string nome)
        {
          

            using (var contexto = Carregar.DadosMemoria())
            using (var pessoa = new PessoaController(contexto))
            {
                var pessoaporNome = pessoa.porNome(nome);

                Assert.NotNull(pessoaporNome);
                Assert.NotEmpty(pessoaporNome.Nome);
            }
        }

    }
}