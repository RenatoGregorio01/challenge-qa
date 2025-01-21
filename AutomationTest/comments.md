# Decisões de Arquitetura e Implementação

## Arquitetura Utilizada

#### Foi utilizada a arquitetura Page Object para organizar os elementos da página e melhorar a manutenibilidade dos testes. Essa abordagem permite:
- Separação de responsabilidades entre os testes e a lógica de negócios.
- Reutilização de código.
- Facilita a manutenção e atualização dos testes.

### Bibliotecas de Terceiros Utilizadas
- coverlet.collector (6.0.0): Cobertura de código.
- DotNetSeleniumExtras.WaitHelpers (3.11.0): Ajuda para esperar elementos na página.
- Microsoft.NET.Test.Sdk (17.8.0): Framework de teste.
- Reqnroll (2.2.1): BDD para .NET.
- Reqnroll.xUnit (2.2.1): Integração com xUnit.
- Selenium.WebDriver (4.27.0): Driver para navegadores.
- Selenium.WebDriver.ChromeDriver (132.0.6834.8300): Driver específico para Chrome.
- xunit (2.5.3): Framework de teste.
- xunit.runner.visualstudio (3.0.1): Corredor de testes para Visual Studio.

## Melhorias Futuras

### Com mais tempo:
- Refatorar métodos repetidos para melhorar a manutenibilidade.
- Criar um fluxo para validar os dois níveis de ensino (graduação e pós-graduação).
- Implementar Fluent Assertions para melhorar a legibilidade dos testes.
- Implementar a biblioteca faker e utilizar os dados gerados.

## Requisitos Obrigatórios Não Entregues
- Não foi implementado o Fluent Assertions.

## Observações
A implementação atual atende aos requisitos básicos, mas há espaço para melhorias. Com mais tempo, é possível refinar a arquitetura e implementar funcionalidades adicionais.