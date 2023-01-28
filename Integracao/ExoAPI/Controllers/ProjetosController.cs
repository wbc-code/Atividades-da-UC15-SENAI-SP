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
    [Authorize]
    public class ProjetosController : Controller
    {
        private readonly ProjetoRepository _repository;

        public ProjetosController(ProjetoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lista todos os projetos cadastrados; requer autenticação
        /// </summary>
        /// <returns>Lista de projetos</returns>
        [HttpGet]
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
        /// Busca por um projeto específico pelo seu id; requer autenticação
        /// </summary>
        /// <param name="id">Id do projeto a ser localizado</param>
        /// <returns>Lista de projetos</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var projeto = _repository.BuscarPorId(id);

                return (projeto != null) ? Ok(projeto) : NotFound("Projeto não encontrado");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insere um novo projeto na base de dados; requer autenticação
        /// </summary>
        /// <param name="projeto">Objeto que contém os dados a serem cadastrados</param>
        /// <returns>Objeto com o id atualizado após ser salvo no banco</returns>
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Projeto projeto)
        {
            try
            {
                return Ok(_repository.Cadastrar(projeto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza os dados de um determinado projeto; requer autenticação
        /// </summary>
        /// <param name="id">Id do projeto a ser atualizado</param>
        /// <param name="projeto">Objeto que contém os dados serem atualizados</param>
        /// <returns>Objeto atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Projeto projeto)
        {
            try
            {
                return Ok(_repository.Atualizar(id, projeto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exclui um determinado projeto; requer autenticação
        /// </summary>
        /// <param name="id">Id do projeto a ser excluído</param>
        /// <returns>True se a exclusão foi feita com sucesso, false caso contrário</returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                if (_repository.Excluir(id))
                {
                    return Ok("Projeto removido");
                }

                return NotFound("Projeto não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

