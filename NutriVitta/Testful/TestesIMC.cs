using System;
using IMC;
using Xunit;

public class TestesIMC
{
    /// <summary>
    /// Testa o cálculo do índice de massa corpórea de uma pessoa
    /// </summary>
    /// <param name="peso">Peso da pessoa, em kg</param>
    /// <param name="altura">Altura da pessoa, em m</param>
    /// <param name="imc">IMC já calculado para confrontar com o resultado do teste</param>
    [Theory]
    [InlineData(52, 1.58, 20.83)]
    [InlineData(48, 1.64, 17.85)]
    [InlineData(74, 1.71, 25.31)]
    [InlineData(100, 1.71, 34.20)]
    public void TestarCalculo(double peso, double altura, double imc)
    {
        var resultado = Calculo.Calcular(peso, altura);

        Assert.Equal(imc, Math.Round(resultado, 2));
    }

    /// <summary>
    /// Testa a classificação do IMC de uma pessoa
    /// </summary>
    /// <param name="imc">IMC da pessoa</param>
    /// <param name="classificacao">Classificação do IMC conforme tabela da Abeso</param>
    [Theory]
    [InlineData(20.83, Classificacao.PesoNormal)]
    [InlineData(17.85, Classificacao.AbaixoDoPeso)]
    [InlineData(25.31, Classificacao.Sobrepeso)]
    [InlineData(34.20, Classificacao.ObesidadeGrauI)]
    public void TestarClassificacao(double imc, Classificacao classificacao)
    {        
        var resultado = Calculo.Classificar(imc);

        Assert.Equal(classificacao, resultado);
    }
}
