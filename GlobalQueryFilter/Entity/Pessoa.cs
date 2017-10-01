using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GlobalQueryFilter.Entity
{
    public class Pessoa
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string WebSite { get; set; }

        //Property for Global Filter Query EF Core 2
        public bool Excluido { get; set; }
        public string Pais { get; set; }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(this);
        }
    }
}
