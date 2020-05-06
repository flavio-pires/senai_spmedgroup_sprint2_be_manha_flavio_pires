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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Retorna uma lista de todas as consultas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto que irá armazenar as informações</param>
        /// <returns>Retorna um Status Code Ok e uma mensagem personalizada</returns>
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return Ok("Nova consulta cadastrada!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto que irá armazenar as novas informações</param>
        /// <returns>Retorna um Status Code Ok e uma mensagem personalizada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);

                if(consultaBuscada != null)
                {
                    _consultaRepository.Atualizar(id, consultaAtualizada);

                    return Ok("Consulta atualizada com sucesso!");
                }

                return NotFound("Nenhuma consulta encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma consulta pelo ID
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>Retorna um Status Code Ok e a consulta buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);

                if(consultaBuscada != null)
                {
                    return Ok(consultaBuscada);
                }

                return NotFound("Nenhuma consulta encontrada para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}