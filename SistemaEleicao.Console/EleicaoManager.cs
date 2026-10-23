namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> _candidatos = new();
    private readonly HashSet<string> _eleitoresQueVotaram = new();
    private readonly Dictionary<int, int> _votosCandidatos = new();

    public IReadOnlyList<Candidato> Candidatos => _candidatos.AsReadOnly();
    public int VotosBrancos { get; private set; }
    public int VotosNulos { get; private set; }

    public void CadastrarCandidato(string nome, int numero)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do candidato não pode ser vazio.", nameof(nome));

        if (_candidatos.Any(c => c.Numero == numero))
            throw new InvalidOperationException($"Já existe um candidato cadastrado com o número duplicado: {numero}.");

        _candidatos.Add(new Candidato(nome, numero));
        _votosCandidatos[numero] = 0;
    }

    public void Votar(string documentoEleitor, int numeroCandidato)
    {
        ValidarEleitor(documentoEleitor);

        if (_candidatos.Any(c => c.Numero == numeroCandidato))
        {
            _votosCandidatos[numeroCandidato]++;
        }
        else
        {
            VotosNulos++;
        }

        _eleitoresQueVotaram.Add(documentoEleitor);
    }

    public void VotarBranco(string documentoEleitor)
    {
        ValidarEleitor(documentoEleitor);
        VotosBrancos++;
        _eleitoresQueVotaram.Add(documentoEleitor);
    }

    public int ObterTotalVotosCandidato(int numero)
    {
        return _votosCandidatos.TryGetValue(numero, out var votos) ? votos : 0;
    }

    public Candidato? ObterVencedor()
    {
        if (!_candidatos.Any()) return null;

        var maisVotado = _candidatos
            .OrderByDescending(c => ObterTotalVotosCandidato(c.Numero))
            .FirstOrDefault();

        return maisVotado;
    }

    private void ValidarEleitor(string documentoEleitor)
    {
        if (string.IsNullOrWhiteSpace(documentoEleitor))
            throw new ArgumentException("O documento do eleitor deve ser informado.", nameof(documentoEleitor));

        if (_eleitoresQueVotaram.Contains(documentoEleitor))
            throw new InvalidOperationException("O eleitor informado já votou anteriormente.");
    }
}