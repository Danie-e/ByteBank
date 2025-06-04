using ByteBank.Modelos.Conta;
using ByteBank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank Atendimento.!");
//TestaArrayDeContas();

#region Exemplo Array Contas

void TestaArrayDeContas()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    ContaCorrente conta = new ContaCorrente(005);

    listaDeContas.Adicionar(new ContaCorrente(001));
    listaDeContas.Adicionar(new ContaCorrente(002));
    listaDeContas.Adicionar(new ContaCorrente(003));
    listaDeContas.Adicionar(new ContaCorrente(004));
    listaDeContas.Adicionar(conta);
    listaDeContas.Adicionar(new ContaCorrente(006));
    //listaDeContas.ExibirLista();

    listaDeContas.Remover(conta);
    Console.WriteLine("");
    //listaDeContas.ExibirLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta1 = listaDeContas[i];
        Console.WriteLine($"Indice: {i}, Conta: {conta1.Numero_agencia}");
    }

}

#endregion

ArrayList _listaDeContas = new ArrayList();
AtendimentoCliente();
void AtendimentoCliente()
{
    char opcao = '0';
    while (opcao != '6')
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===       Atendimento       ===");
        Console.WriteLine("===1 - Cadastrar Conta      ===");
        Console.WriteLine("===2 - Listar Contas        ===");
        Console.WriteLine("===3 - Remover Conta        ===");
        Console.WriteLine("===4 - Ordenar Contas       ===");
        Console.WriteLine("===5 - Pesquisar Conta      ===");
        Console.WriteLine("===6 - Sair do Sistema      ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n\n");

        Console.Write("Digite a opção desejada: ");
        opcao = Console.ReadLine()[0];

        switch (opcao)
        {
            case '1':
                CadastrarConta();
                break;
            case '2':
                ListarContas();
                break;
            default:
                Console.WriteLine("Opcao não implementada.");
                break;
        }

    }

    void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia);

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }

    void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não há contas cadastradas! ...");
            Console.ReadKey();
            return;
        }

        foreach (ContaCorrente item in _listaDeContas)
        {
            Console.WriteLine("===  Dados da Conta  ===");
            Console.WriteLine("Número da Conta : " + item.Conta);
            Console.WriteLine("Saldo da Conta : " + item.Saldo);
            Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
            Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
            Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }
}
