using AutoCheckConsole;

    void ExibirMenu()
    {   
        Console.WriteLine("===================================================");
        Console.WriteLine("Bem vindo ao Sistema de Vistoria Técnica Automotiva");
        Console.WriteLine("===================================================");
        Console.WriteLine("Escolha uma opção para continuar: ");
        Console.WriteLine("1 - Realizar Nova Vistoria");
        Console.WriteLine("2 - Exibir Relatório de Vistorias");
        Console.WriteLine("0 - Sair");
    }

    int opcao; 
    do
    {
        ExibirMenu();
        opcao = Convert.ToInt16(Console.ReadLine());
        switch (opcao)
        {
            case 1:
            Console.WriteLine("opcao1");
            break;

            case 2:
            Console.WriteLine("opcao2");
            break;
        }
    } while (opcao != 0);