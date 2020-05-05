using Microsoft.EntityFrameworkCore;
using Senai.Spmedgroup.WebApi.Contexts;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id);

            if(pacienteBuscado != null)
            {
                if(pacienteAtualizado != null)
                {
                    pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
                    pacienteBuscado.Rg = pacienteAtualizado.Rg;
                    pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
                    pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                    pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
                    pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;
                    pacienteBuscado.IdEndereco = pacienteAtualizado.IdEndereco;
                }

                ctx.Paciente.Update(pacienteBuscado);

                ctx.SaveChanges();
            }
        }

        public Paciente BuscarPorId(int id)
        {
            Paciente pacienteBuscado = ctx.Paciente
                .Include(p => p.IdEnderecoNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefault(p => p.IdPaciente == id);

            if(pacienteBuscado != null)
            {
                return pacienteBuscado;
            }

            return null;

        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Paciente.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Paciente.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Paciente
                .Include(p => p.IdEnderecoNavigation)
                .Include(p => p.IdUsuarioNavigation)

                .ToList();
        }
    }
}
