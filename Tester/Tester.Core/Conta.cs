using System;

namespace Tester.Core
{
	public class Conta
	{
		public double Saldo { get; private set; }

		public Conta(double saldo)
		{
			Saldo = saldo;
		}

		public void Depositar(double valor)
        {
			if (valor <= 0)
            {
				throw new ArgumentOutOfRangeException("Valor a ser depositado precisa ser maior do que zero");
            }

			Saldo += valor;
        }

	}
}

