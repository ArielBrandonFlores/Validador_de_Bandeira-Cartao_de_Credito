public class LuhnValidator : ILuhnValidator
{
    public bool Validate(string numero)
    {
        numero = numero.Replace(" ", "").Replace("-", "");
        if (!long.TryParse(numero, out _)) return false;

        int soma = 0;
        bool alternar = false;
        for (int i = numero.Length - 1; i >= 0; i--)
        {
            int digito = numero[i] - '0';
            if (alternar)
            {
                digito *= 2;
                if (digito > 9) digito -= 9;
            }
            soma += digito;
            alternar = !alternar;
        }
        return soma % 10 == 0;
    }
}