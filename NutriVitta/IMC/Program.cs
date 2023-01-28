do
{
    Console.Write("Informe seu peso (em kg): ");
    var peso = double.Parse(Console.ReadLine());

    Console.Write("Informe sua altura (em m): ");
    var altura = double.Parse(Console.ReadLine());

    Console.WriteLine();

    var imc = IMC.Calculo.Calcular(peso, altura);
    var classificacao = IMC.Calculo.Classificar(imc);

    Console.WriteLine($"Seu IMC é {Math.Round(imc, 2)} e a classificação é {classificacao}");
    Console.WriteLine();
    Console.Write("Calcular novamente? S/N: ");

} while (Console.ReadLine().Equals("S"));