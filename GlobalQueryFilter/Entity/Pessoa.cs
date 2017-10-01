using System;
using Newtonsoft.Json;

namespace GlobalQueryFilter.Entity
{
    public class Pessoa
    {
        [JsonIgnore]
        public Guid ID { get; set; }

        public string Nome { get; set; }
        public string WebSite { get; set; }

        //Property for Global Filter Query EF Core 2
        [JsonIgnore]
        public bool Excluido { get; set; }

        public string Pais { get; set; }

        public override string ToString()
        {

            return JsonConvert.SerializeObject(this);
        }
    }
}
