using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }

        [Required(ErrorMessage = "O nome do médico é obrigatório!")]
        public string NomeMedico { get; set; }

        [Required(ErrorMessage = "O CRM do médico é obrigatório!")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "A identificação do usuário é obrigatória!")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "A identificação da especialidade é obrigatória!")]
        public int? IdEspecialidade { get; set; }

        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
