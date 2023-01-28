using System;
using ExoAPI.Contexts;
using ExoAPI.Interfaces;
using ExoAPI.Models;
using ExoAPI.Tools;

namespace ExoAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ExoContext _context;

        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            var usuarios = _context.Usuarios.ToList();

            foreach (var usuario in usuarios)
            {
                usuario.Senha = String.Empty;
            }

            return usuarios;
        }

        public Usuario BuscarPorId(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario != null)
            {
                usuario.Senha = string.Empty;
            }

            return usuario;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            usuario.Perfil = Enumeradores.PerfilUsuario.Usuario;
            usuario.Senha = Password.Hash(usuario.Senha);

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            usuario.Senha = string.Empty;

            return usuario;
        }

        public Usuario Atualizar(int id, Usuario usuario)
        {
            var usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Perfil = usuario.Perfil;
                usuarioBuscado.Senha = Password.Hash(usuario.Senha);

                _context.Usuarios.Update(usuarioBuscado);
                _context.SaveChanges();

                usuarioBuscado.Senha = String.Empty;
            }

            return usuarioBuscado;
        }

        public bool Excluir(int id)
        {
            var usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioBuscado != null)
            {
                _context.Usuarios.Remove(usuarioBuscado);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public Usuario Entrar(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(Password.Hash(senha)));
        }
    }
}
