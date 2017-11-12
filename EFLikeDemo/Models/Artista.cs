using System;

namespace EFLikeDemo.Models
{
    public class Artista
    {
        public Guid ID { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public int Idade { get; set; }

        public Artista()
        {
            ID = Guid.NewGuid();
        }
    }
}