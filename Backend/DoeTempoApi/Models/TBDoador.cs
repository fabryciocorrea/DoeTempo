using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoeTempoApi.Models
{
    [Table("TBDoador")]
    public class TBDoador
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public double Id { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }

        [Display(Name = "Sobrenome")]
        [Column("Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Idade")]
        [Column("Idade")]
        public int Idade { get; set; }

        [Display(Name = "Celular")]
        [Column("Celular")]
        public string Celular { get; set; }

        [Display(Name = "EnderecoCep")]
        [Column("EnderecoCep")]
        public string EnderecoCep { get; set; }

        [Display(Name = "EnderecoNumero")]
        [Column("EnderecoNumero")]
        public string EnderecoNumero { get; set; }

        [Display(Name = "Cidade")]
        [Column("Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Column("Estado")]
        public string Estado { get; set; }

        [Display(Name = "Competencia1")]
        [Column("Competencia1")]
        public string Competencia1 { get; set; }

        [Display(Name = "Competencia2")]
        [Column("Competencia2")]
        public string Competencia2 { get; set; }

        [Display(Name = "Competencia3")]
        [Column("Competencia3")]
        public string Competencia3 { get; set; }

        [Display(Name = "Competencia4")]
        [Column("Competencia4")]
        public string Competencia4 { get; set; }

        [Display(Name = "Competencia5")]
        [Column("Competencia5")]
        public string Competencia5 { get; set; }

        /*
        public TBDoador(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
        */
    }
}
