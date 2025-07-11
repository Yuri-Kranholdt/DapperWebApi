﻿namespace DapperWebApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cargo { get; set; }

        public double Salario { get; set; }

        public string CPF { get; set; }

        public bool Situacao { get; set; } // ativo inativo

        public string Senha { get; set; }
    }
}
