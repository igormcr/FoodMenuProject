# RandomMenuProject

Projeto Razor Pages em `.NET 8` para geração/visualização de menus aleatórios.

## Descrição

Aplicação web construída com Razor Pages. Fornece páginas para gerar e exibir menus aleatórios — fácil de executar e estender.

## Pré-requisitos

- `.NET 8 SDK` instalado (verifique com `dotnet --version`).
- (Opcional) Visual Studio 2022/2023 ou Visual Studio Code.

## Executando localmente

1. Restaurar dependências:

```
dotnet restore
```

2. Compilar:

```
dotnet build
```

3. Executar o projeto (exemplo caso o projeto esteja na raiz do repositório):

```
dotnet run --project RandomMenuProject
```

Ou abra a solução no Visual Studio e inicie a depuração.

## Estrutura típica

- `Pages/` — páginas Razor (`Index.cshtml`, `Index.cshtml.cs`, etc.)
- `wwwroot/` — arquivos estáticos (CSS, JS, imagens)
- `appsettings.json` — configurações
- `Program.cs` — configuração e ponto de entrada

## Configuração

- Use `appsettings.json` e variáveis de ambiente para configurações.
- Para segredos locais, use `dotnet user-secrets` quando aplicável.

## Como contribuir

1. Abra uma issue para discutir alterações.
2. Crie uma branch para a sua alteração.
3. Envie um pull request com descrição clara.

## Licença

Adicione o tipo de licença do projeto (por exemplo, `MIT`) ou remova esta seção se não aplicável.

## Contato

Abra issues no repositório para dúvidas, sugestões e reportes de bugs.
