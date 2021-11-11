using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoeTempoApi.Models
{
    [Table("TBUsuarioDoador")]
    public class TBUsuarioDoacao
    {
        [Display(Name = "IdDoador")]
        [Column("IdDoador")]
        public double IdDoador { get; set; }

        [Display(Name = "IdUsuario")]
        [Column("IdUsuario")]
        public double IdUsuario { get; set; }

        [Display(Name = "NomeUsuario")]
        [Column("NomeUsuario")]
        public string NomeUsuario { get; set; }

        public TBUsuarioDoacao(double idDoador, double idUsuario, string nomeUsuario)
        {
            IdDoador = idDoador;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
        }
    }
}
