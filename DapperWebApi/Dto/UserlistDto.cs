﻿namespace DapperWebApi.Dto
{
    public class UserlistDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cargo { get; set; }

        public double Salario { get; set; }

        public bool Situacao { get; set; } // ativo inativo

    }
}
