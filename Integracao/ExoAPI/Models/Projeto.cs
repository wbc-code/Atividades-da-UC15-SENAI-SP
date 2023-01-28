using System;
using ExoAPI.Enumeradores;

namespace ExoAPI.Models
{
	public class Projeto
	{
		public Projeto()
		{
		}

		public int Id { get; set; }

		public string Titulo { get; set; }

		public DateTime Inicio { get; set; }

		public StatusProjeto Status { get; set; }

		public string Tecnologias { get; set; }
	}
}

