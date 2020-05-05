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
    public class EnderecoRepository : IEnderecoRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Atualizar(int id, Endereco enderecoAtualizado)
        {
            Endereco enderecoBuscado = ctx.Endereco.Find(id);

            if(enderecoBuscado != null)
            {
                if(enderecoAtualizado != null)
                {
                    enderecoBuscado.NomeLogradouro = enderecoAtualizado.NomeLogradouro;
                    enderecoBuscado.NumeroLogradouro = enderecoAtualizado.NumeroLogradouro;
                    enderecoBuscado.Bairro = enderecoAtualizado.Bairro;
                    enderecoBuscado.Cep = enderecoAtualizado.Cep;
                    enderecoBuscado.IdCidade = enderecoAtualizado.IdCidade;
                    enderecoBuscado.IdEstado = enderecoAtualizado.IdEstado;
                }

                ctx.Endereco.Update(enderecoBuscado);

                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Endereco novoEndereco)
        {
            ctx.Endereco.Add(novoEndereco);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Endereco enderecoBuscado = ctx.Endereco.Find(id);

            ctx.Endereco.Remove(enderecoBuscado);

            ctx.SaveChanges();
        }

        public List<Endereco> Listar()
        {
            return ctx.Endereco
                .Include(e => e.IdCidadeNavigation)
                .Include(e => e.IdEstadoNavigation)

                .ToList();
        }
    }
}
