using System.IdentityModel.Tokens.Jwt;
using ExoAPI.Controllers;
using ExoAPI.Interfaces;
using ExoAPI.Models;
using ExoAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Testes;

public class TestesAPI
{
    [Fact]
    public void TestarLoginInvalido()
    {
        // Arrange
        var repository = new Mock<IUsuarioRepository>();
        repository.Setup(x => x.Entrar(string.Empty, string.Empty)).Returns((Usuario) null);

        var usuario = new Usuario
        {
            Email = string.Empty,
            Senha = string.Empty
        };

        var controller = new LoginController(repository.Object);

        // Act
        var resultado = controller.EfetuarLogin(usuario);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(resultado);
    }

    [Fact]    
    public void TestarLoginValido()
    {
        // Arrange
        var usuario = new Usuario
        {
            Email = "teste@teste.com",
            Senha = Password.Hash("12345")
        };

        var repository = new Mock<IUsuarioRepository>();
        repository.Setup(x => x.Entrar(It.IsAny<string>(), It.IsAny<string>())).Returns(usuario);

        var controller = new LoginController(repository.Object);

        var issuer = "exoapi";

        // Act
        var resultado = (OkObjectResult)controller.EfetuarLogin(usuario);

        var token = JsonConvert.DeserializeObject<Login>(resultado.Value.ToString());

        var handler = new JwtSecurityTokenHandler();

        var partes = handler.ReadJwtToken(token.Token);

        // Assert
        Assert.Equal(issuer, partes.Issuer);
    }    
}