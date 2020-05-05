using Senai.Spmedgroup.WebApi.Contexts;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacao.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Situacao situacaoBuscada = ctx.Situacao.Find(id);

            ctx.Situacao.Remove(situacaoBuscada);

            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacao.ToList();
        }
    }
}
