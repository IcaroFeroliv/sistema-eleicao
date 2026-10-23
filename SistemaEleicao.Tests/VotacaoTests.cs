namespace SistemaEleicao.Tests;

using SistemaEleicao.Console;
using Xunit;

public class VotacaoTests
{
    [Fact]
    public void Votar_EleitorVotandoPelaPrimeiraVez_DeveComputarVotoComSucesso()
    {
        // Arrange
        var manager = new EleicaoManager();
        manager.CadastrarCandidato("Maria Silva", 10);

        // Act
        manager.Votar("123456", 10);

        // Assert
        Assert.Equal(1, manager.ObterTotalVotosCandidato(10));
    }

    [Fact]
    public void Votar_MesmoEleitorVotandoDuasVezes_DeveLancarExcecao()
    {
        // Arrange
        var manager = new EleicaoManager();
        manager.CadastrarCandidato("Maria Silva", 10);
        manager.Votar("123456", 10);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            manager.Votar("123456", 10);
        });

        Assert.Contains("já votou", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Votar_CandidatoInexistente_DeveContabilizarComoVotoNulo()
    {
        // Arrange
        var manager = new EleicaoManager();
        manager.CadastrarCandidato("Maria Silva", 10);

        // Act (voto no número 99 inexistente)
        manager.Votar("999999", 99);

        // Assert
        Assert.Equal(1, manager.VotosNulos);
    }

    [Fact]
    public void Votar_VotoEmBranco_DeveContabilizarComoBranco()
    {
        // Arrange
        var manager = new EleicaoManager();

        // Act (definindo 0 como voto em branco, por exemplo)
        manager.VotarBranco("888888");

        // Assert
        Assert.Equal(1, manager.VotosBrancos);
    }
}