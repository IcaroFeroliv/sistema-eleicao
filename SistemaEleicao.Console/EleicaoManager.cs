namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> _candidatos = new();
    public IReadOnlyList<Candidato> Candidatos => _candidatos.AsReadOnly();

    public void CadastrarCandidato(string nome, int numero)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do candidato não pode ser vazio.", nameof(nome));

        if (_candidatos.Any(c => c.Numero == numero))
            throw new InvalidOperationException($"Já existe um candidato cadastrado com o número duplicado: {numero}.");

        _candidatos.Add(new Candidato(nome, numero));
    }
}