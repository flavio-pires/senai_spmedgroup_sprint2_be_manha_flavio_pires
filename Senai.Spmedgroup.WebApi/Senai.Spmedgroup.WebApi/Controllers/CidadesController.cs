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
    public class CidadesController : ControllerBase
    {
        private ICidadeRepository _cidadeRepository;

        public CidadesController()
        {
            _cidadeRepository = new CidadeRepository();
        }

        /// <summary>
        /// Lista todas as cidades
        /// </summary>
        /// <returns>Retorna uma lista de todas as cidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_cidadeRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova cidade
        /// </summary>
        /// <param name="novaCidade">Objeto que irá armazenar as informações</param>
        /// <returns>Retorna o Status Code Ok e uma mensagem personalizada</returns>
        [HttpPost]
        public IActionResult Post(Cidade novaCidade)
        {
            try
            {
                _cidadeRepository.Cadastrar(novaCidade);

                return Ok("Nova cidade cadastrada!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma cidade
        /// </summary>
        /// <param name="id">ID da cidade que será deletada</param>
        /// <returns>Retorna o Status Code Ok e uma mensagem personalizada</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Cidade cidadeBuscada = _cidadeRepository.BuscarPorId(id);

                if(cidadeBuscada != null)
                {
                    _cidadeRepository.Deletar(id);

                    return Ok("Cidade deletada!");
                }

                return NotFound("Nenhuma cidade encontrada!");
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}