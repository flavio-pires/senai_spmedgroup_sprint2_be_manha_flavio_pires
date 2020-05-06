using Microsoft.EntityFrameworkCore.Internal;
using Senai.Spmedgroup.WebApi.Contexts;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Cadastrar(Cidade novaCidade)
        {
            ctx.Cidade.Add(novaCidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cidade cidadeBuscada = ctx.Cidade.Find(id);

            ctx.Cidade.Remove(cidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Cidade> Listar()
        {
            return ctx.Cidade.ToList();
        }

        public Cidade BuscarPorId(int id)
        {
            Cidade cidadeBuscada = ctx.Cidade.FirstOrDefault(c => c.IdCidade == id);

            if(cidadeBuscada != null)
            {
                return cidadeBuscada;
            }

            return null;
        }
    }
}
