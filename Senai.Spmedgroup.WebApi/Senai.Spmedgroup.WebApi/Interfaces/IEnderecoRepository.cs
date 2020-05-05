using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IEnderecoRepository
    {
        List<Endereco> Listar();

        void Cadastrar(Endereco novoEndereco);

        void Atualizar(int id, Endereco enderecoAtualizado);

        void Deletar(int id);
    }
}
