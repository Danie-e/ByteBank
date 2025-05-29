using ByteBank.Modelos.Conta;

namespace ByteBank.Util;

public class ListaDeContasCorrentes
{
    public ListaDeContasCorrentes(int tamanhoInicial = 4)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;

    public void Adicionar(ContaCorrente conta)
    {
        Console.WriteLine($"Conta adicionado na posição {_proximaPosicao}");
        VerificarCapacidade(_proximaPosicao + 1);
        _itens[_proximaPosicao] = conta;
        _proximaPosicao++;
    }

    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
            return;
        Console.WriteLine("Aumentando capacidade do array");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }
}
