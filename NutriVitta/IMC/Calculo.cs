using System;

namespace IMC
{
	public static class Calculo
	{
		/// <summary>
        /// Calcula o índice de massa corpórea de uma pessoa (peso dividido pela altura ao quadrado)
        /// </summary>
        /// <param name="peso">Peso da pessoa, em kg</param>
        /// <param name="altura">Altura da pessoa, em m</param>
        /// <returns>IMC calculado</returns>
		public static double Calcular(double peso, double altura)
        {
			return peso / (altura * altura);
        }

		/// <summary>
        /// Classifica o IMC de uma pessoa de acordo com a tabela da Abeso
        /// </summary>
        /// <param name="imc">Índice de massa corpórea</param>
        /// <returns>Classificação</returns>
		public static Classificacao Classificar(double imc)
        {
			Classificacao classificacao;

			if (imc < 18.5)
            {
				classificacao = Classificacao.AbaixoDoPeso;
            }
			else if (imc >= 18.5 && imc < 24.9)
            {
				classificacao = Classificacao.PesoNormal;
            }
			else if (imc >= 25 && imc < 29.9)
            {
				classificacao = Classificacao.Sobrepeso;
            }
			else if (imc >= 30 && imc < 34.9)
			{
				classificacao = Classificacao.ObesidadeGrauI;
			}
			else if (imc >= 35 && imc < 39.9)
			{
				classificacao = Classificacao.ObesidadeGrauII;
			}
			else
			{
				classificacao = Classificacao.ObesidadeGrauIII;
			}

			return classificacao;
		}
	}
}

