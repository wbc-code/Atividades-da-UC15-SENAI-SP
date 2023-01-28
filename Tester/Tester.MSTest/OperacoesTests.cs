using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tester.Core;

namespace Tester.MSTest;

[TestClass]
public class OperacoesTests
{
    [TestMethod]
    public void SomarDoisNumeros()
    {
        double numero1 = 10;
        double numero2 = 20;

        var resultado = Operacoes.Somar(numero1, numero2);

        Assert.AreEqual(30, resultado);
    }

    [TestMethod]
    public void MultiplicarDoisNumeros()
    {
        double numero1 = 5;
        double numero2 = 6;

        var resultado = Operacoes.Multiplicar(numero1, numero2);

        Assert.AreEqual(30, resultado);
    }
}
