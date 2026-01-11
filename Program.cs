using System;

class Program
{
    static void Main(string[] args)
    {
        // Configuração das dependências seguindo DIP
        var bandeiraValidators = new BandeiraValidators();
        var luhnValidator = new LuhnValidator();
        var validador = new ValidadorCartaoCredito(bandeiraValidators, luhnValidator);

        Console.WriteLine("Validador de Cartão de Crédito");
        Console.WriteLine("Digite o número do cartão (ou 'sair' para encerrar):");

        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToLower() == "sair") break;

            var (valido, bandeira) = validador.ValidarCartao(input);
            if (valido)
            {
                Console.WriteLine($"Cartão válido. Bandeira: {bandeira}");
            }
            else
            {
                Console.WriteLine($"Cartão inválido ou bandeira desconhecida: {bandeira}");
            }
        }
    }
}
