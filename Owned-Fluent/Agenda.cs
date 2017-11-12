namespace Owned_Fluent
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Contato Comercial  { get; set; }
        public Contato Residencial { get; set; }
    }

    public class Contato
    {
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}