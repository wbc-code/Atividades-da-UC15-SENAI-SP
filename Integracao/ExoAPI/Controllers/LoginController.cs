using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExoAPI.Interfaces;
using ExoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ExoAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public LoginController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Permite ao usuário efetuar login no site
        /// </summary>
        /// <param name="usuario">Objeto que contém o e-mail e a senha para se logar</param>
        /// <returns>Token a ser usado nas próximas chamadas para autenticação</returns>
        [HttpPost]
        public IActionResult EfetuarLogin([FromBody]Usuario usuario)
        {
            var usuarioLogado = _repository.Entrar(usuario.Email, usuario.Senha);

            if (usuarioLogado == null)
            {
                return Unauthorized("Usuário e/ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(JwtRegisteredClaimNames.Sid, usuarioLogado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioLogado.Perfil.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-autenticacao-bearer"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "exoapi",
                audience: "exoapi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credenciais
            );

            return Ok(JsonConvert.SerializeObject(new { token = new JwtSecurityTokenHandler().WriteToken(token) } ));
        }
    }
}

