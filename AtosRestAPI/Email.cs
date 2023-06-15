using System.Text.Json.Serialization;

namespace AtosRestAPI
{
    public class Email
    {
        public int Id { get; set; }

        public string Email1 { get; set; } = null!;

        public int? FkPessoa { get; set; }

        [JsonIgnore]
        public virtual Pessoa? FkPessoaNavigation { get; set; }
    }
}
