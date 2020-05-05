using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IEstadoRepository
    {
        List<Estado> Listar();

        void Cadastrar(Estado novoEstado);

        void Deletar(int id);
    }
}
