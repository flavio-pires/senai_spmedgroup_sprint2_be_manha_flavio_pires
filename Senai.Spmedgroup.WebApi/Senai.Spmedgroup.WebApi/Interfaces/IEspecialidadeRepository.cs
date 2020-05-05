using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int id, Especialidade especialidadeAtualizada);

        Especialidade BuscarPorId(int id);

        void Deletar(int id);
    }
}
