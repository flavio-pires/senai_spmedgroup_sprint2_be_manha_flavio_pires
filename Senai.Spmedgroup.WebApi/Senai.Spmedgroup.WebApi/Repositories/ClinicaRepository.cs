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
    public class ClinicaRepository : IClinicaRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            if(clinicaBuscada != null)
            {
                if(clinicaAtualizada != null)
                {
                    clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
                    clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                    clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                    clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;
                    clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;
                    clinicaBuscada.IdEndereco = clinicaAtualizada.IdEndereco;
                }

                ctx.Clinica.Update(clinicaBuscada);

                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinica.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            ctx.Clinica.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinica
                .Include("IdEnderecoNavigation")
                .ToList();
        }
    }
}
