using Microsoft.EntityFrameworkCore;
using Senai.Spmedgroup.WebApi.Contexts;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Repositories
{

    public class ConsultaRepository : IConsultaRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if(consultaBuscada != null)
            {
                if(consultaAtualizada != null)
                {
                    consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
                    consultaBuscada.HorarioConsulta = consultaAtualizada.HorarioConsulta;
                    consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
                    consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                    consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
                }

                ctx.Consulta.Update(consultaBuscada);

                ctx.SaveChanges();
            }
        }

        public Consulta BuscarPorId(int id)
        {
            Consulta consultaBuscada = ctx.Consulta
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdSituacaoNavigation)
                .FirstOrDefault(c => c.IdConsulta == id);

            if(consultaBuscada != null)
            {
                return consultaBuscada;
            }

            return null;
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdSituacaoNavigation)

                .ToList();
        }
    }
}
