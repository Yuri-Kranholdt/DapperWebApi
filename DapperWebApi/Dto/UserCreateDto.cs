using System.Text.Json.Serialization;

namespace DapperWebApi.Dto
{
    public class UserCreateDto
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cargo { get; set; }

        public double Salario { get; set; }

        public string CPF { get; set; }

        [JsonIgnore]
        public bool Situacao { get; set; } = true; // ativo inativo

        public string Senha { get; set; } 
    }
}
