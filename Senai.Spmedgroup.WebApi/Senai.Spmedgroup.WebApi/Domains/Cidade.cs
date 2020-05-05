using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Cidade
    {
        public Cidade()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int IdCidade { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório!")]
        public string NomeCidade { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
