using ByteBank.Atendimento;
using ByteBank.Modelos.Conta;

partial class Program
{
    private static void Main(string[] args)
    {
        List<ContaCorrente> _listaDeContas = new();
        Console.WriteLine("Boas Vindas ao ByteBank Atendimento.!");

        string enderecoArquivo = "contas.txt";

        using (FileStream fluxoDeArquivo = new(enderecoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                ContaCorrente conta = ConverteStringParaContaCorrente(linha);
                _listaDeContas.Add(conta);
            }

        }
        new Atendimento().AtendimentoCliente(_listaDeContas);

    }
}