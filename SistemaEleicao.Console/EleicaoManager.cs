namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> _candidatos = new();
    public IReadOnlyList<Candidato> Candidatos => _candidatos.AsReadOnly();

    public void CadastrarCandidato(string nome, int numero)
    {
        // Deixar vazio ou lançar NotImplementedException inicialmente
        throw new NotImplementedException();
    }
}