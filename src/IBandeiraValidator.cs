using System.Text.RegularExpressions;

public interface IBandeiraValidator
{
    BandeiraCartao Bandeira { get; }
    bool IsValid(string numero);
}