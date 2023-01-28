using System;
using ExoAPI.Contexts;
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
	public class ProjetoRepository
	{
		private readonly ExoContext _context;

		public ProjetoRepository(ExoContext context)
		{
			_context = context;
		}

		public List<Projeto> Listar()
        {
			return _context.Projetos.ToList();
        }

		public Projeto BuscarPorId(int id)
        {
			return _context.Projetos.Find(id);
        }

		public Projeto Cadastrar(Projeto projeto)
        {
			_context.Projetos.Add(projeto);
			_context.SaveChanges();

			return projeto;
        }

		public Projeto Atualizar(int id, Projeto projeto)
        {
			var projetoBuscado = _context.Projetos.Find(id);

			if (projetoBuscado != null)
            {				
				projetoBuscado.Status = projeto.Status;
				projetoBuscado.Tecnologias = projeto.Tecnologias;
				projetoBuscado.Titulo = projeto.Titulo;

				_context.Projetos.Update(projetoBuscado);
				_context.SaveChanges();
            }

			return projetoBuscado;
        }

		public bool Excluir(int id)
        {
			var projeto = _context.Projetos.Find(id);

			if (projeto != null)
            {
				_context.Projetos.Remove(projeto);
				_context.SaveChanges();

				return true;
            }

			return false;
        }
	}
}

