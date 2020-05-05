using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clinica = new HashSet<Clinica>();
            Paciente = new HashSet<Paciente>();
        }

        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "O nome do logradouro é obrigatório!")]
        public string NomeLogradouro { get; set; }

        [Required(ErrorMessage = "O número do logradouro é obrigatório!")]
        public int NumeroLogradouro { get; set; }

        [Required(ErrorMessage = "O nome do bairro é obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O cep do endereço é obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O número de identificação da cidade é obrigatório!")]
        public int? IdCidade { get; set; }

        [Required(ErrorMessage = "O número de identificação da estado é obrigatório!")]
        public int? IdEstado { get; set; }

        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Clinica> Clinica { get; set; }
        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
