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
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            Especialidade especialidadeBuscada = ctx.Especialidade.Find(id);

            if(especialidadeBuscada != null)
            {
                if(especialidadeAtualizada != null)
                {
                    especialidadeBuscada.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;
                }

                ctx.Especialidade.Update(especialidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public Especialidade BuscarPorId(int id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id);

            if(especialidadeBuscada != null)
            {
                return especialidadeBuscada;
            }

            return null;
        }

        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidade.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Especialidade.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidade.ToList();
        }
    }
}
