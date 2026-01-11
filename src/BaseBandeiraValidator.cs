using System.Text.RegularExpressions;

public abstract class BaseBandeiraValidator : IBandeiraValidator
{
    protected readonly Regex Pattern;

    protected BaseBandeiraValidator(string pattern)
    {
        Pattern = new Regex(pattern);
    }

    public abstract BandeiraCartao Bandeira { get; }

    public bool IsValid(string numero)
    {
        numero = numero.Replace(" ", "").Replace("-", "");
        return Pattern.IsMatch(numero);
    }
}