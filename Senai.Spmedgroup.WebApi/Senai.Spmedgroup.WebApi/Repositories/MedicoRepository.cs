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
    public class MedicoRepository : IMedicoRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medico.Find(id);

            if(medicoBuscado != null)
            {
                if(medicoAtualizado != null)
                {
                    medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
                    medicoBuscado.Crm = medicoAtualizado.Crm;
                    medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
                    medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
                }

                ctx.Medico.Update(medicoBuscado);

                ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(int id)
        {
            Medico medicoBuscado = ctx.Medico
                .Include(m => m.IdEspecialidadeNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefault(m => m.IdMedico == id);

            if(medicoBuscado != null)
            {
                return medicoBuscado;
            }

            return null;
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medico.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Medico.Find(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medico
                .Include(m => m.IdEspecialidadeNavigation)
                .Include(m => m.IdUsuarioNavigation)

                .ToList();
        }
    }
}
