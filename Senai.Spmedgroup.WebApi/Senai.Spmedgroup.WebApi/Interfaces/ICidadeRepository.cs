using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface ICidadeRepository
    {

        List<Cidade> Listar();

        void Cadastrar(Cidade novaCidade);

        void Deletar(int id);

        Cidade BuscarPorId(int id);
    }
}
