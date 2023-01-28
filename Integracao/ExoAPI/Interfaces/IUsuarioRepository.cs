using ExoAPI.Models;

namespace ExoAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Atualizar(int id, Usuario usuario);
        Usuario BuscarPorId(int id);
        Usuario Cadastrar(Usuario usuario);
        Usuario Entrar(string email, string senha);
        bool Excluir(int id);
        List<Usuario> Listar();
    }
}