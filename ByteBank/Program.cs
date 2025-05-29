using ByteBank.Modelos.Conta;
using ByteBank.Util;

Console.WriteLine("Hello, World!");
TestaArrayDeContas();

void TestaArrayDeContas()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(001));
    listaDeContas.Adicionar(new ContaCorrente(002));
    listaDeContas.Adicionar(new ContaCorrente(003));
    listaDeContas.Adicionar(new ContaCorrente(004));
    listaDeContas.Adicionar(new ContaCorrente(005));
    listaDeContas.Adicionar(new ContaCorrente(006));

    listaDeContas.ExibirLista();

    listaDeContas.Remover(new ContaCorrente(005));
    Console.WriteLine("");
    listaDeContas.ExibirLista();

}