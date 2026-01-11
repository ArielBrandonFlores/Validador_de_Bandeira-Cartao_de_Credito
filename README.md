# Validador de Bandeira de Cartão de Crédito
## Descrição

Este projeto foi desenvolvido como um desafio de codificação para demonstrar habilidades em C#, design orientado a objetos e boas práticas de desenvolvimento. O validador identifica a bandeira do cartão com base no número fornecido e aplica a validação do checksum via algoritmo de Luhn, garantindo que o número seja válido para transações.

O código evoluiu de uma implementação inicial simples para uma arquitetura robusta, utilizando Regex para padrões eficientes, injeção de dependência e princípios SOLID para extensibilidade e manutenção.

## Funcionalidades

- **Identificação de Bandeira**: Detecta automaticamente a bandeira do cartão (Visa, Mastercard, American Express, etc.) com base no prefixo e comprimento do número.
- **Validação de Checksum**: Aplica o algoritmo de Luhn para verificar se o número do cartão é válido.
- **Suporte a Múltiplas Bandeiras**:
  - Visa (13, 16 ou 19 dígitos)
  - Mastercard (16 dígitos)
  - American Express (15 dígitos)
  - Diners Club (14 dígitos)
  - Discover (16 dígitos)
  - EnRoute (15 dígitos)
  - JCB (16 dígitos)
  - Voyage (15 dígitos)
  - HiperCard (16 dígitos)
  - Aura (16 dígitos)
- **Interface Interativa**: Permite entrada de números via console para validação em tempo real.
- **Extensibilidade**: Fácil adição de novas bandeiras sem modificar código existente, graças ao design SOLID.

## Tecnologias Utilizadas

- **Linguagem**: C# (.NET 9.0)
- **Framework**: .NET Core/Console Application
- **Bibliotecas**: System.Text.RegularExpressions (para validação de padrões)
- **Paradigmas**: Programação Orientada a Objetos, Princípios SOLID, Injeção de Dependência

## Estrutura do Projeto

```
Validador de Bandeira Cartão de Crédito/
├── src/
│   ├── BandeiraCartao.cs              # Enum com as bandeiras suportadas
│   ├── IBandeiraValidator.cs          # Interface para validadores de bandeira
│   ├── BaseBandeiraValidator.cs       # Classe base abstrata para validadores
│   ├── BandeiraValidators.cs          # Classe com dicionário de Regex para todas as bandeiras
│   ├── ILuhnValidator.cs              # Interface para validação Luhn
│   ├── LuhnValidator.cs               # Implementação da validação Luhn
│   ├── ValidadorCartaoCredito.cs      # Classe principal que coordena a validação
├── Program.cs                         # Ponto de entrada da aplicação
├── Validador de Bandeira Cartão de Crédito.csproj  # Arquivo de projeto .NET
└── README.md                          # Este arquivo
```

## Instalação e Execução

### Pré-requisitos

- .NET 9.0 SDK instalado (disponível em [dotnet.microsoft.com](https://dotnet.microsoft.com/download))

### Passos para Executar

1. Clone ou baixe o repositório.
2. Navegue até a pasta do projeto:
   ```
   cd "Validador de Bandeira Cartão de Crédito"
   ```
3. Restaure as dependências:
   ```
   dotnet restore
   ```
4. Execute o aplicativo:
   ```
   dotnet run
   ```
5. Digite um número de cartão no console (ex.: `4111111111111111`) e pressione Enter.
6. O aplicativo retornará se o cartão é válido e qual a bandeira.
7. Digite "sair" para encerrar.

### Exemplo de Uso

```
Validador de Cartão de Crédito
Digite o número do cartão (ou 'sair' para encerrar):
4111111111111111
Cartão válido. Bandeira: Visa

Digite o número do cartão (ou 'sair' para encerrar):
5555555555554444
Cartão válido. Bandeira: Mastercard

Digite o número do cartão (ou 'sair' para encerrar):
1234567890123456
Cartão inválido ou bandeira desconhecida: Desconhecida
```

## Arquitetura e Design

O projeto segue os princípios SOLID para garantir código limpo, testável e extensível:

- **S (Single Responsibility)**: Cada classe tem uma responsabilidade única (ex.: `LuhnValidator` só valida Luhn, `VisaValidator` só valida Visa).
- **O (Open/Closed)**: Aberto para extensão (adicionar bandeiras via novas classes) sem modificar código existente.
- **L (Liskov Substitution)**: Qualquer `IBandeiraValidator` pode ser substituído sem quebrar a funcionalidade.
- **I (Interface Segregation)**: Interfaces pequenas e específicas (`IBandeiraValidator`, `ILuhnValidator`).
- **D (Dependency Inversion)**: Dependência de abstrações (interfaces) em vez de concretos, com injeção via construtor.

### Padrões Utilizados

- **Strategy Pattern**: Cada validador de bandeira é uma estratégia para identificar a bandeira.
- **Factory/Composition**: A classe principal compõe os validadores via injeção de dependência.
- **Regex**: Para validação eficiente de padrões de números de cartão.

## Contribuição

Para adicionar uma nova bandeira:

1. Crie uma nova classe em `src/Validators/` herdando de `BaseBandeiraValidator`.
2. Implemente o padrão Regex no construtor.
3. Adicione a instância na lista de `bandeiraValidators` em `Program.cs`.

Exemplo:

```csharp
public class NovaBandeiraValidator : BaseBandeiraValidator
{
    public NovaBandeiraValidator() : base(@"^prefixo\d{comprimento}$") { }
    public override BandeiraCartao Bandeira => BandeiraCartao.NovaBandeira;
}
```

## Licença

Este projeto é de código aberto e pode ser usado livremente para fins educacionais ou comerciais. Sinta-se à vontade para contribuir ou adaptar conforme necessário.

---

Desenvolvido com ❤️ em C# para demonstrar boas práticas de desenvolvimento.
