using ByteBank.Modelos.Conta;
using ByteBank.Util;

Console.WriteLine("Hello, World!");
TestaArrayDeContas();

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