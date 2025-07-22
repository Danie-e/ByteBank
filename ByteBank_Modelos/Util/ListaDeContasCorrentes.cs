using ByteBank.Modelos.Conta;

namespace ByteBank.Util;

public class ListaDeContasCorrentes
{
    public ListaDeContasCorrentes(int tamanhoInicial = 4)
    {
        _itens = new ContaCorrente[tamanhoInicial];
    }

    public ContaCorrente this[int indice]
    {
        get { return RecuperarContaIndice(indice); }
    }

    private ContaCorrente[] _itens = null;
    private int _proximaPosicao = 0;
    public int Tamanho
    {
        get
        {
            return _proximaPosicao;
        }
    }
    public void Adicionar(ContaCorrente conta)
    {
        //Console.WriteLine($"Conta adicionado na posição {_proximaPosicao}");
        VerificarCapacidade(_proximaPosicao + 1);
        _itens[_proximaPosicao] = conta;
        _proximaPosicao++;
    }

    public void Remover(ContaCorrente conta)
    {
        int indiceItem = 1;
        for (int i = 0; i < _proximaPosicao; i++)
        {
            ContaCorrente contaAtual = _itens[i];
            if (contaAtual == conta)
            {
                indiceItem = i;
                break;
            }
        }

        for (int i = indiceItem; i < _proximaPosicao - 1; i++)
        {
            _itens[i] = _itens[i + 1];
        }
        _proximaPosicao--;
        _itens[_proximaPosicao] = null;
    }

    public void ExibirLista()
    {
        for (int i = 0; i < _itens.Length; i++)
        {
            if (_itens[i] != null)
            {
                Console.WriteLine($"Conta: {_itens[i].Conta}");
            }
        }
    }

    public ContaCorrente RecuperarContaIndice(int indice)
    {
        if (indice < 0 || indice >= _proximaPosicao)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
        return _itens[indice];
    }

    private void VerificarCapacidade(int tamanhoNecessario)
    {
        if (_itens.Length >= tamanhoNecessario)
            return;
        //Console.WriteLine("Aumentando capacidade do array");
        ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

        for (int i = 0; i < _itens.Length; i++)
        {
            novoArray[i] = _itens[i];
        }

        _itens = novoArray;
    }
}
