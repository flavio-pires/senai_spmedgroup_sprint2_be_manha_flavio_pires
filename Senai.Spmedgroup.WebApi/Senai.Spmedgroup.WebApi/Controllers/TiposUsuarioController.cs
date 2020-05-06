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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista dos tipos de usuário</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto que armazena as informações do novo tipo de usuário</param>
        /// <returns>Retorna o status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        /// <returns>Status Code Ok e uma mensagem personalizada</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if(tipoUsuarioBuscado != null)
                {
                    _tipoUsuarioRepository.Deletar(id);

                    return Ok("Tipo de usuário deletado!");
                }

                return NotFound("Nenhum tipo de usuário encontrado para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}