using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> Listar();

        void Cadastrar(Situacao novaSituacao);

        void Deletar(int id);
    }
}
