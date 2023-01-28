using System;
using ExoAPI.Enumeradores;

namespace ExoAPI.Models
{
	public class Usuario
	{
		public Usuario()
		{
		}

		public int Id { get; set; }

		public string Nome { get; set; }

		public string Email { get; set; }
				
		public string Senha { get; set; }

		public PerfilUsuario Perfil { get; set; }
	}
}

