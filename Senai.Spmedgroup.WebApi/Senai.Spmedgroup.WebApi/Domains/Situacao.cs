using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }

        [Required(ErrorMessage = "O título da situação é obrigatório!")]
        public string TituloSituacao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
