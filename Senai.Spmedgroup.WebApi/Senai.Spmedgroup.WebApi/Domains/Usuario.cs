using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medico = new HashSet<Medico>();
            Paciente = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres")]
        public string Senha { get; set; }
        public int? IdClinica { get; set; }
        public int? IdTipoUsuario { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medico { get; set; }
        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
