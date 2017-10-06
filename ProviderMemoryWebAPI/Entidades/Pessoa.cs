using System;

namespace ProviderMemoryWebAPI.Entidades
{
    public class Pessoa
    {
       
        public Guid ID { get; set; }

        public string Nome { get; set; }
        public string WebSite { get; set; }

        public bool Excluido { get; set; }

        public string Pais { get; set; }
    }
}