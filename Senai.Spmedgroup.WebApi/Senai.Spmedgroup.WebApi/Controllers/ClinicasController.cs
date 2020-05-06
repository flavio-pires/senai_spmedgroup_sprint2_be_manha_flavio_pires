using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Spmedgroup.WebApi.Domains;
using Senai.Spmedgroup.WebApi.Interfaces;
using Senai.Spmedgroup.WebApi.Repositories;

namespace Senai.Spmedgroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Retorna uma lista de todas as clínicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Objeto que irá armazenar as informações</param>
        /// <returns>Retorna um Status Code Ok e uma mensagem personalizada</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return Ok("Nova clínica cadastrada!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma clínica existente
        /// </summary>
        /// <param name="id">ID da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto que vai armazenar as novas informações</param>
        /// <returns>Retorna um Status Code Ok e uma mensagem personalizada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

                if(clinicaBuscada != null)
                {
                    _clinicaRepository.Atualizar(id, clinicaAtualizada);

                    return Ok("Clínica atualizada!");
                }

                return NotFound("Nenhuma clínica encontrada!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma clínica
        /// </summary>
        /// <param name="id">ID da clínica que será deletada</param>
        /// <returns>Retorna um Status Code Ok e uma mensagem personalizada</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

                if(clinicaBuscada != null)
                {
                    _clinicaRepository.Deletar(id);

                    return Ok("Clínica deletada!");
                }

                return NotFound("Nenhuma clínica encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}