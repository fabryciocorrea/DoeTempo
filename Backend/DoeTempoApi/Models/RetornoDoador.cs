using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoeTempoApi.Models
{
    public class RetornoDoador
    {
        public double Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Celular { get; set; }
        public string Competencia { get; set; }

        public RetornoDoador(double id, string nome, string sobrenome, string email, string cidade, string estado, string celular, string competencia)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Cidade = cidade;
            Estado = estado;
            Celular = celular;
            Competencia = competencia;
        }
    }
}
