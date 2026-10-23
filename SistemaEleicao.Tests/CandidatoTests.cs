namespace SistemaEleicao.Tests;

using SistemaEleicao.Console;
using Xunit;

public class CandidatoTests
{
    [Fact]
    public void CadastrarCandidato_ComDadosValidos_DeveAdicionarALista()
    {
        // Arrange
        var manager = new EleicaoManager();

        // Act
        manager.CadastrarCandidato("Maria Silva", 10);

        // Assert
        Assert.Single(manager.Candidatos);
        Assert.Equal("Maria Silva", manager.Candidatos[0].Nome);
        Assert.Equal(10, manager.Candidatos[0].Numero);
    }

    [Fact]
    public void CadastrarCandidato_ComNumeroDuplicado_DeveLancarExcecao()
    {
        // Arrange
        var manager = new EleicaoManager();
        manager.CadastrarCandidato("Maria Silva", 10);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            manager.CadastrarCandidato("João Santos", 10);
        });

        Assert.Contains("duplicado", ex.Message, StringComparison.OrdinalIgnoreCase);
    }
}