using Senai.Spmedgroup.WebApi.Contexts;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Cadastrar(Estado novoEstado)
        {
            ctx.Estado.Add(novoEstado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estado estadoBuscado = ctx.Estado.Find(id);

            ctx.Estado.Remove(estadoBuscado);

            ctx.SaveChanges();
        }

        public List<Estado> Listar()
        {
            return ctx.Estado.ToList();
        }
    }
}
