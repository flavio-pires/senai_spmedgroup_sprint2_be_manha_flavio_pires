using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "O nome fantasia é obrigatório!")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ da clínica é obrigatório!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "A razão social da clínica é obrigatória!")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O horário de abertura da clínica é obrigatório!")]
        public TimeSpan HorarioAbertura { get; set; }

        [Required(ErrorMessage = "O horário de fechamento da clínica é obrigatório!")]
        public TimeSpan HorarioFechamento { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
