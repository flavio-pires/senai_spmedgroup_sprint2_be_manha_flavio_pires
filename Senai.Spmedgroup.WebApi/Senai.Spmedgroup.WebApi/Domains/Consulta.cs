using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Spmedgroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória!")]
        public DateTime? DataConsulta { get; set; }

        [Required(ErrorMessage = "O horário da consulta é obrigatório!")]
        public TimeSpan HorarioConsulta { get; set; }

        [Required(ErrorMessage = "Informe a identificação do médico que realizará o atendimento!")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Informe a identificação do paciente que receberá o atendimento!")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "A situação da consulta é obrigatória!")]
        public int? IdSituacao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
