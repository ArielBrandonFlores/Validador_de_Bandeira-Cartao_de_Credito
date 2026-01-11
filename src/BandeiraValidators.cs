using System.Text.RegularExpressions;

public class BandeiraValidators
{
    private static readonly Dictionary<BandeiraCartao, Regex> Padroes = new()
    {
        { BandeiraCartao.Visa, new Regex(@"^4(\d{12}|\d{15}|\d{18})$") },
        { BandeiraCartao.Mastercard, new Regex(@"^(5[1-5]|2[2-7])\d{14}$") },
        { BandeiraCartao.AmericanExpress, new Regex(@"^(34|37)\d{13}$") },
        { BandeiraCartao.DinersClub, new Regex(@"^(300|301|302|303|304|305|36|38)\d{11}$") },
        { BandeiraCartao.Discover, new Regex(@"^6011\d{12}$") },
        { BandeiraCartao.EnRoute, new Regex(@"^(2014|2149)\d{11}$") },
        { BandeiraCartao.JCB, new Regex(@"^35\d{14}$") },
        { BandeiraCartao.Voyage, new Regex(@"^8699\d{11}$") },
        { BandeiraCartao.HiperCard, new Regex(@"^6062\d{12}$") },
        { BandeiraCartao.Aura, new Regex(@"^50\d{14}$") }
    };

    public BandeiraCartao IdentificarBandeira(string numero)
    {
        numero = numero.Replace(" ", "").Replace("-", "");
        if (!long.TryParse(numero, out _)) return BandeiraCartao.Desconhecida;

        foreach (var (bandeiraKey, regex) in Padroes)
        {
            if (regex.IsMatch(numero))
                return bandeiraKey;
        }
        return BandeiraCartao.Desconhecida;
    }
}