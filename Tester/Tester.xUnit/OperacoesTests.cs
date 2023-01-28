using Tester.Core;
using Xunit;

namespace Tester.xUnit;

public class OperacoesTests
{
    [Fact]
    public void SomarDoisNumeros()
    {
        double numero1 = 10;
        double numero2 = 20;

        var resultado = Operacoes.Somar(numero1, numero2);

        Assert.Equal(30, resultado);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    public void SomarDoisNumerosMultiplasVezes(double numero1, double numero2, double resultado)
    {
        var soma = Operacoes.Somar(numero1, numero2);

        Assert.Equal(resultado, soma);
    }
}
