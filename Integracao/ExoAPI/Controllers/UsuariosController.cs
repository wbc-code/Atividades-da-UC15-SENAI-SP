using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExoAPI.Models;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]    
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _repository;

        public UsuariosController(UsuarioRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lista todos os usuários cadastrados; requer autenticação
        /// </summary>
        /// <returns>Lista de usuários</returns>        
        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_repository.Listar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca por um usuário específico; requer autenticação
        /// </summary>
        /// <param name="id">Id do usuário a ser localizado</param>
        /// <returns>Usuário encontrado</returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var usuario = _repository.BuscarPorId(id);

                return (usuario != null) ? Ok(usuario) : NotFound("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insere um novo usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Objeto que contém os dados a serem persistidos</param>
        /// <returns>Objeto com id atualizado após ser salvo no banco</returns>
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Usuario usuario)
        {
            try
            {
                return Ok(_repository.Cadastrar(usuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza um determinado usuário; requer autenticação
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuario">Objeto que contém os dados a serem persistidos</param>
        /// <returns>Objeto atualizado</returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Atualizar(int id, [FromBody]Usuario usuario)
        {
            try
            {
                return Ok(_repository.Atualizar(id, usuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exclui um determinado usuário do banco de dados; requer autenticação e perfil de administrador
        /// </summary>
        /// <param name="id">Id do usuário a ser excluído</param>
        /// <returns>True se exclusão feita com sucesso, false caso contrário</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Excluir(int id)
        {
            try
            {
                if (_repository.Excluir(id))
                {
                    return Ok("Usuário removido");
                }

                return NotFound("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

