# Validador de Bandeira de Cartão de Crédito

## Visão Geral

Aplicação console desenvolvida em **C# (.NET 9.0)** capaz de identificar a bandeira de cartões de crédito e validar sua autenticidade utilizando o **algoritmo de Luhn**.  
O projeto foi construído com forte ênfase em **arquitetura limpa**, **princípios SOLID** e **extensibilidade**, sendo ideal como projeto de portfólio técnico.

Este repositório faz parte de um desafio proposto pela DIO, no qual o objetivo é ir além da implementação básica, documentando decisões técnicas e aplicando boas práticas de engenharia de software.

---

## Contexto do Desafio

A proposta do desafio consiste em **recriar ou evoluir** um projeto base, utilizando o GitHub como plataforma de versionamento e exposição profissional, além do **GitHub Copilot** como assistente de codificação.

### Objetivos de Aprendizagem

Ao concluir este projeto, foram trabalhadas as seguintes competências:

- Reproduzir e evoluir um projeto a partir de código existente  
- Aplicar conceitos em um cenário prático e realista  
- Documentar decisões técnicas de forma clara e objetiva  
- Utilizar o GitHub como vitrine profissional  

---

## Descrição Técnica

O sistema identifica a bandeira do cartão com base em **prefixo e comprimento**, aplicando em seguida a validação de checksum por meio do algoritmo de **Luhn**.

A implementação evoluiu de uma solução simples para uma arquitetura mais robusta, utilizando:

- Expressões regulares para detecção eficiente de padrões  
- Inversão de dependência  
- Separação clara de responsabilidades  
- Design preparado para extensão sem modificação de código existente  

---

## Funcionalidades

- **Identificação Automática de Bandeira**
- **Validação de Checksum (Algoritmo de Luhn)**
- **Interface Interativa via Console**
- **Arquitetura Extensível (SOLID)**

### Bandeiras Suportadas

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

---

## Diferenciais em Relação ao Projeto Base

- Arquitetura orientada a interfaces  
- Aplicação completa dos princípios SOLID  
- Separação entre validação de bandeira e validação de checksum  
- Código aberto para extensão e fechado para modificação  
- Estrutura preparada para testes automatizados e futuras integrações  

---

## Tecnologias Utilizadas

- **Linguagem**: C#  
- **Plataforma**: .NET 9.0  
- **Tipo de Aplicação**: Console Application  
- **Bibliotecas**: System.Text.RegularExpressions  
- **Paradigmas**:
  - Programação Orientada a Objetos  
  - Princípios SOLID  
  - Injeção de Dependência  

---

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
