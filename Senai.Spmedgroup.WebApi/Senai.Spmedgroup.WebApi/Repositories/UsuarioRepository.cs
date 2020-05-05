using Microsoft.EntityFrameworkCore;
using Senai.Spmedgroup.WebApi.Contexts;
using Senai.Spmedgroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Spmedgroup.WebApi.Repositories
{
    public class UsuarioRepository
    {
        SpmedicalgroupContext ctx = new SpmedicalgroupContext();

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um usuário através do id
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Verifica se foi informado um e-mail de usuário
                if (usuarioAtualizado.Email != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

                // Verifica se foi informada uma senha de usuário
                if (usuarioAtualizado.Senha != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.Senha = usuarioAtualizado.Senha;
                }

                // Verifica se foi informado o tipo do usuário
                if (usuarioAtualizado.IdTipoUsuario != null)
                {
                    // Atribui o novo valor ao campo
                    usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                }

                // Atualiza os dados do usuário que foi buscado
                ctx.Usuario.Update(usuarioBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um usuário por ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        public Usuario BuscarPorId(int id)
        {
            // Busca o primeiro usuário encontrado para o ID informado e armazena no objeto usuarioBuscado
            // Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == id);

            // Outra forma
            // Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Outra forma, não mostrando a senha
            Usuario usuarioBuscado = ctx.Usuario
               // Seleciona apenas os dados que devem ser mostrados
               .Select(u => new Usuario()
               {
                   IdUsuario = u.IdUsuario,
                   Email = u.Email,

                   IdTipoUsuarioNavigation = new TipoUsuario()
                   {
                       IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                       TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                   },

                   IdClinicaNavigation = new Clinica()
                   {
                       IdClinica = u.IdClinicaNavigation.IdClinica,
                       NomeFantasia = u.IdClinicaNavigation.NomeFantasia
                   }
               })
               .FirstOrDefault(u => u.IdUsuario == id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações de cadastro</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona um novo usuário
            ctx.Usuario.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o usuário que foi buscado através do id informado
            ctx.Usuario.Remove(BuscarPorId(id));

            // Outra forma

            // Busca um usuário através do id
            // Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Remove o usuário que foi buscado
            // ctx.Usuario.Remove(uUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos usuários
            //return ctx.Usuario.ToList();

            // Outra forma, não mostrando a senha
            return ctx.Usuario
               // Seleciona apenas os dados que devem ser mostrados
               .Select(u => new Usuario()
               {
                   IdUsuario = u.IdUsuario,
                   Email = u.Email,

                   IdTipoUsuarioNavigation = new TipoUsuario()
                   {
                       IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                       TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                   },

                   IdClinicaNavigation = new Clinica()
                   {
                       IdClinica = u.IdClinicaNavigation.IdClinica,
                       NomeFantasia = u.IdClinicaNavigation.NomeFantasia
                   }
               })
               .ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um usuário autenticado</returns>
        public Usuario Login(string email, string senha)
        {
            // Busca o primeiro usuário encontrado para o e-mail e a senha informados e armazena no objeto usuarioBuscado
            Usuario usuarioBuscado = ctx.Usuario
                // Busca as informações referentes ao tipo de usuário
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }
    }
}
