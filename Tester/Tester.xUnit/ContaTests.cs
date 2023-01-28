using System;
using Tester.Core;
using Xunit;

namespace Tester.xUnit
{
	public class ContaTests
	{
        [Fact]
		public void DepositoValido()
        {
			double saldoInicial = 20;
			double valorDepositado = 4.55;
			double saldoEsperado = 24.55;

			var conta = new Conta(saldoInicial);

			conta.Depositar(valorDepositado);

			Assert.Equal(saldoEsperado, conta.Saldo);
        }

        [Fact]
		public void DepositoInvalido()
        {
			double saldoInicial = 20;
			double valorDepositado = -8;

			var conta = new Conta(saldoInicial);

			Assert.Throws<ArgumentOutOfRangeException>(() => conta.Depositar(valorDepositado));
        }
	}
}

