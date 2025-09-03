# C14
Simples aplicação que faz cálculos matemáticos em C#.

## Compilação
Faça o download da [SDK do .NET 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0), navegue até o diretório do arquivo *C14.csproj* com sua CLI e utilize os seguintes comandos:
- *dotnet restore*
- *dotnet build*

As dependências serão resolvidas pelo gerenciador de pacotes [NuGet](https://learn.microsoft.com/pt-br/nuget/what-is-nuget).

Também é possível gerenciar os pacotes NuGet e gerar o executável utilizando o [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/):
- Abra o arquivo *C14.sln*
- Clique com o botão direito em "**Solução 'C14'**"
- Clique em "**Restaurar pacotes NuGet**"
- Clique novamente com o botão direito em "**Solução 'C14'**"
- Clique em "**Compilar Solução**"

## Execução
É necessário baixar [o runtime do .NET 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) caso a aplicação não seja compilada utilizando [publish](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish) para que ela possa ser [self-contained](https://learn.microsoft.com/en-us/dotnet/core/deploying/)

## Testes
Foi utilizado a suíte de testes [xUnit](https://xunit.net/?tabs=cs). Os testes podem ser facilmente rodados no Visual Studio utilizando o menu **Teste > Rodar todos os testes**.

## Dependências
[ MathNet.Numerics](https://www.nuget.org/packages/MathNet.Numerics/5.0.0?_src=template)  
[xUnit](https://www.nuget.org/packages/xunit)
