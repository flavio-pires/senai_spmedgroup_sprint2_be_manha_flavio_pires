using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório!")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "O rg do paciente é obrigatório!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O cpf do paciente é obrigatório!")]
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "A identificação do usuário é obrigatória!")]
        public int? IdUsuario { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
