using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Listar();

        void Cadastrar(Medico novoMedico);

        Medico BuscarPorId(int id);

        void Atualizar(int id, Medico medicoAtualizado);

        void Deletar(int id);
    }
}
