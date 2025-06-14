﻿using ByteBank.Exceptions;
using ByteBank.Modelos.Conta;
using ByteBank.Util;

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

List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
    new ContaCorrente(95) {Saldo=100,Titular=new(){Nome="Daniela",Profissao="Dev",Cpf="123456789" } },
    new ContaCorrente(95) {Saldo=200,Titular=new(){Nome="Julio",Profissao="Tester",Cpf="789456123" }},
    new ContaCorrente(94) {Saldo=60,Titular=new(){Nome="Isabela",Profissao="Desiner",Cpf="741258963" }}
};
AtendimentoCliente();
void AtendimentoCliente()
{
    try
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
            try
            {
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
                    case '3':
                        RemoverConta();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
            catch (Exception excecao)
            {
                throw new ByteBankException(excecao.Message);
            }
        }
    }
    catch (ByteBankException e)
    {
        Console.WriteLine(e.Message);
    }
}

void RemoverConta()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("===      REMOVER CONTAS     ===");
    Console.WriteLine("===============================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (ContaCorrente item in _listaDeContas)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }
    if (conta != null)
    {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        Console.WriteLine(" ... Conta para remoção não encontrada ...");
    }
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


#region Teste Listas

//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874),
//    new ContaCorrente(874),
//    new ContaCorrente(874)
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951),
//    new ContaCorrente(321),
//    new ContaCorrente(719)
//};

//_listaDeContas2.AddRange(_listaDeContas3);
//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//var range = _listaDeContas3.GetRange(0, 1);
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine();
//_listaDeContas3.Clear();
//for (int i = 0; i < _listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas3[i].Conta}]");
//}

#endregion

Generica<int> teste1 = new Generica<int>();
//teste1.MostrarMensagem(0);

Generica<string> teste2 = new Generica<string>();
//teste2.MostrarMensagem("teste");
public class Generica<T>
{
    public void MostrarMensagem(T t)
    {
        Console.WriteLine($"Exibindo {t}");
    }
}

