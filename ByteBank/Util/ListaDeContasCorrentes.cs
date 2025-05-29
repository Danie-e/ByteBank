using ByteBank.Modelos.Conta;

namespace ByteBank.Util;

public class ListaDeContasCorrentes
{
    public ListaDeContasCorrentes(int tamanhoInicial = 5)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;

    public void Adicionar(ContaCorrente conta)
    {
        Console.WriteLine($"Conta adicionado na posição {_proximaPosicao}");
        _itens[_proximaPosicao] = conta;
        _proximaPosicao++;
    }
}
