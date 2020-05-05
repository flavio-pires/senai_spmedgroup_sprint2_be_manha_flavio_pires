using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medico = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }

        [Required(ErrorMessage = "O nome da especialidade é obrigatório!")]
        public string NomeEspecialidade { get; set; }

        public virtual ICollection<Medico> Medico { get; set; }
    }
}
