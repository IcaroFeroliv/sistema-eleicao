using SistemaEleicao.Console;

var manager = new EleicaoManager();
var executando = true;

while (executando)
{
    Console.WriteLine("\n=== SISTEMA DE ELEIÇÃO ===");
    Console.WriteLine("1 - Cadastrar Candidato");
    Console.WriteLine("2 - Votar");
    Console.WriteLine("3 - Votar em Branco");
    Console.WriteLine("4 - Apuração dos Votos");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarCandidatoUI(manager);
            break;
        case "2":
            VotarUI(manager);
            break;
        case "3":
            VotarBrancoUI(manager);
            break;
        case "4":
            ApurarVotosUI(manager);
            break;
        case "0":
            executando = false;
            Console.WriteLine("A encerrar o sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida! Prima qualquer tecla para continuar.");
            break;
    }
}

static void CadastrarCandidatoUI(EleicaoManager manager)
{
    Console.Write("\nNome do Candidato: ");
    var nome = Console.ReadLine();

    Console.Write("Número do Candidato: ");
    if (!int.TryParse(Console.ReadLine(), out var numero))
    {
        Console.WriteLine("Número inválido! O número deve ser inteiro.");
        return;
    }

    try
    {
        manager.CadastrarCandidato(nome ?? string.Empty, numero);
        Console.WriteLine("Candidato cadastrado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao cadastrar candidato: {ex.Message}");
    }
}

static void VotarUI(EleicaoManager manager)
{
    Console.Write("\nDocumento do Eleitor (CPF/Título): ");
    var documento = Console.ReadLine();

    Console.Write("Número do Candidato escolhido: ");
    if (!int.TryParse(Console.ReadLine(), out var numero))
    {
        Console.WriteLine("Número inválido!");
        return;
    }

    try
    {
        manager.Votar(documento ?? string.Empty, numero);
        Console.WriteLine("Voto computado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao votar: {ex.Message}");
    }
}

static void VotarBrancoUI(EleicaoManager manager)
{
    Console.Write("\nDocumento do Eleitor (CPF/Título): ");
    var documento = Console.ReadLine();

    try
    {
        manager.VotarBranco(documento ?? string.Empty);
        Console.WriteLine("Voto em branco registado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao votar em branco: {ex.Message}");
    }
}

static void ApurarVotosUI(EleicaoManager manager)
{
    Console.WriteLine("\n=== RESULTADO DA APURAÇÃO ===");
    
    foreach (var candidato in manager.Candidatos)
    {
        var total = manager.ObterTotalVotosCandidato(candidato.Numero);
        Console.WriteLine($"Candidato: {candidato.Nome} ({candidato.Numero}) - Votos: {total}");
    }

    Console.WriteLine($"Votos em Branco: {manager.VotosBrancos}");
    Console.WriteLine($"Votos Nulos: {manager.VotosNulos}");

    var vencedor = manager.ObterVencedor();
    if (vencedor != null)
    {
        var votosVencedor = manager.ObterTotalVotosCandidato(vencedor.Numero);
        Console.WriteLine($"\nCandidato Vencedor: {vencedor.Nome} com {votosVencedor} voto(s).");
    }
    else
    {
        Console.WriteLine("\nNenhum candidato registado na eleição.");
    }
}