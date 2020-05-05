using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        void Cadastrar(Consulta novaConsulta);

        Consulta BuscarPorId(int id);

        void Atualizar(int id, Consulta consultaAtualizada);

    }
}
