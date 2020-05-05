using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int IdEstado { get; set; }

        [Required(ErrorMessage = "O nome do estado é obrigatório!")]
        public string NomeEstado { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
