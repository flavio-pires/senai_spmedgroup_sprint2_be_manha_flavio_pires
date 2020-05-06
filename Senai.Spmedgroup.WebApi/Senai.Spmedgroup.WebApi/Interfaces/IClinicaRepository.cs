using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> Listar();

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int id, Clinica clinicaAtualizada);

        void Deletar(int id);

        Clinica BuscarPorId(int id);
    }
}
