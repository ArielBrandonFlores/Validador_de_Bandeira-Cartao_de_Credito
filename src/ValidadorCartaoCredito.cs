using System.Collections.Generic;

public class ValidadorCartaoCredito
{
    private readonly BandeiraValidators _bandeiraValidators;
    private readonly ILuhnValidator _luhnValidator;

    public ValidadorCartaoCredito(BandeiraValidators bandeiraValidators, ILuhnValidator luhnValidator)
    {
        _bandeiraValidators = bandeiraValidators;
        _luhnValidator = luhnValidator;
    }

    public BandeiraCartao IdentificarBandeira(string numero)
    {
        return _bandeiraValidators.IdentificarBandeira(numero);
    }

    public (bool valido, BandeiraCartao bandeira) ValidarCartao(string numero)
    {
        BandeiraCartao bandeira = IdentificarBandeira(numero);
        if (bandeira == BandeiraCartao.Desconhecida) return (false, bandeira);
        bool valido = _luhnValidator.Validate(numero);
        return (valido, bandeira);
    }
}