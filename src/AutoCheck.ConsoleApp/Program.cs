using AutoCheckConsole;
List<Veiculo> veiculosVistoriados = new List<Veiculo>();

void ExibirMenu()
{
    Console.WriteLine("===================================================");
    Console.WriteLine("Bem vindo ao Sistema de Vistoria Técnica Automotiva");
    Console.WriteLine("===================================================");
    Console.WriteLine("Escolha uma opção para continuar: ");
    Console.WriteLine("1 - Realizar Nova Vistoria");
    Console.WriteLine("2 - Exibir Relatório de Vistorias");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");
}

int LerInteiro(string mensagem)
{
    Console.Write(mensagem);
    int valor;
    while (!int.TryParse(Console.ReadLine(), out valor))
    {
        Console.Write("Valor inválido, digite um número inteiro: ");
    }
    return valor;
}

double LerDouble(string mensagem)
{
    Console.Write(mensagem);
    double valor;
    while (!double.TryParse(Console.ReadLine(), out valor))
    {
        Console.Write("Valor inválido, digite um número: ");
    }
    return valor;
}

string LerTexto(string mensagem)
{
    Console.Write(mensagem);
    string? texto = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(texto))
    {
        Console.Write("Valor não pode ser vazio, digite novamente: ");
        texto = Console.ReadLine();
    }
    return texto;
}

string LerStatus(string nomeItem)
{
    while (true)
    {
        Console.Write($"Status do item \"{nomeItem}\" (Bom / Regular / Ruim): ");
        string status = Console.ReadLine() ?? "";

        if (status.ToLower() == "bom" || status.ToLower() == "regular" || status.ToLower() == "ruim")
        {
            return status.ToLower();
        }

        Console.WriteLine("Status inválido. Aceito apenas: Bom, Regular ou Ruim.");
    }
}

Veiculo? CriarVeiculo()
{
    Console.WriteLine();
    Console.WriteLine("Tipo de veículo:");
    Console.WriteLine("1 - Carro");
    Console.WriteLine("2 - Moto");
    Console.WriteLine("3 - Caminhão");
    int tipo = LerInteiro("Opção: ");

    string marca = LerTexto("Marca: ");
    string modelo = LerTexto("Modelo: ");
    int ano = LerInteiro("Ano: ");
    int quilometragem = LerInteiro("Quilometragem (km): ");

    if (tipo == 1)
    {
        int portas = LerInteiro("Quantidade de Portas: ");
        return new Carro(marca, modelo, ano, quilometragem, new List<ItemVistoria>(), portas);
    }
    else if (tipo == 2)
    {
        int cilindradas = LerInteiro("Cilindradas: ");
        return new Moto(marca, modelo, ano, quilometragem, new List<ItemVistoria>(), cilindradas);
    }
    else if (tipo == 3)
    {
        int eixos = LerInteiro("Quantidade de Eixos: ");
        double capacidade = LerDouble("Capacidade de Carga (toneladas): ");
        return new Caminhao(marca, modelo, ano, quilometragem, new List<ItemVistoria>(), eixos, capacidade);
    }

    Console.WriteLine("Tipo de veículo inválido.");
    return null;
}

void ExibirRelatorio(Veiculo veiculo, ResultadoVistoria resultado)
{
    Console.WriteLine();
    Console.WriteLine("===================================================");
    Console.WriteLine("           RELATÓRIO DE VISTORIA VEICULAR         ");
    Console.WriteLine("===================================================");
    Console.WriteLine($"Tipo:            {veiculo.ObterTipo()}");
    Console.WriteLine($"Marca/Modelo:    {veiculo.Marca} {veiculo.Modelo}");
    Console.WriteLine($"Ano:             {veiculo.Ano}");
    Console.WriteLine($"Quilometragem:   {veiculo.Quilometragem} km");
    Console.WriteLine(veiculo.ObterDadosEspecificos());
    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine("Itens Vistoriados:");

    foreach (ItemVistoria item in veiculo.VistoriaRealizada)
    {
        int pontos = MotorVistoria.ObterPontuacaoPorStatus(item.Status);
        Console.WriteLine($"  - {item.Nome,-35} | Status: {item.Status,-8} | Pontos: {pontos}");
    }

    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine($"Pontuação Obtida:  {resultado.PontuacaoObtida} / {resultado.PontuacaoMaximaPossivel}");
    Console.WriteLine($"Percentual:        {resultado.Percentual:F2}%");
    Console.WriteLine($"Classificação:     {resultado.Classificacao}");
    Console.WriteLine($"Ação Corporativa:  {resultado.AcaoCorporativa}");
    Console.WriteLine("---------------------------------------------------");

    if (resultado.ItensCriticos.Count > 0)
    {
        Console.WriteLine("🔴 Itens Críticos / Reprovados:");
        foreach (ItemVistoria item in resultado.ItensCriticos)
        {
            Console.WriteLine($"   - {item.Nome} (exige troca/reparo obrigatório)");
        }
    }
    else
    {
        Console.WriteLine("🔴 Itens Críticos / Reprovados: Nenhum.");
    }

    if (resultado.ItensAtencao.Count > 0)
    {
        Console.WriteLine("🟡 Itens de Atenção:");
        foreach (ItemVistoria item in resultado.ItensAtencao)
        {
            Console.WriteLine($"   - {item.Nome} (exige revisão preventiva)");
        }
    }
    else
    {
        Console.WriteLine("🟡 Itens de Atenção: Nenhum.");
    }

    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine("Recomendação de Serviços da Oficina:");
    foreach (string linha in resultado.Recomendacoes)
    {
        Console.WriteLine(linha);
    }
    Console.WriteLine("===================================================");
    Console.WriteLine();
}

void RealizarNovaVistoria()
{
    Veiculo? veiculo = CriarVeiculo();
    if (veiculo == null)
    {
        return;
    }

    List<string> checklist = veiculo.ObterChecklistObrigatorio();

    Console.WriteLine();
    Console.WriteLine("--- Preenchimento do Checklist Obrigatório ---");
    foreach (string itemNome in checklist)
    {
        string status = LerStatus(itemNome);
        veiculo.AdicionarItemVistoriado(itemNome, status);
    }

    ResultadoVistoria resultado = MotorVistoria.ProcessarVistoria(veiculo);
    ExibirRelatorio(veiculo, resultado);

    veiculosVistoriados.Add(veiculo);
}

void ExibirRelatorioGeral()
{
    if (veiculosVistoriados.Count == 0)
    {
        Console.WriteLine();
        Console.WriteLine("Nenhuma vistoria foi realizada ainda.");
        Console.WriteLine();
        return;
    }

    for (int i = 0; i < veiculosVistoriados.Count; i++)
    {
        Veiculo veiculo = veiculosVistoriados[i];
        ResultadoVistoria resultado = MotorVistoria.ProcessarVistoria(veiculo);
        Console.WriteLine($"Vistoria #{i + 1}");
        ExibirRelatorio(veiculo, resultado);
    }
}

int opcao;
do
{
    ExibirMenu();
    string entrada = Console.ReadLine() ?? "";
    if (!int.TryParse(entrada, out opcao))
    {
        opcao = -1;
    }

    switch (opcao)
    {
        case 1:
            RealizarNovaVistoria();
            break;

        case 2:
            ExibirRelatorioGeral();
            break;

        case 0:
            Console.WriteLine("Encerrando o sistema. Até logo!");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            Console.WriteLine();
            break;
    }
} while (opcao != 0);