using ByteBank.Modelos.Conta;
using ByteBank.Util;
using System.ComponentModel.DataAnnotations;

partial class Program
{
    private static void Main(string[] args)
    {
        //EscritaBinaria();
        UsarStreamDeEntrada();

        ListaDeContasCorrentes _listaDeContas = new ListaDeContasCorrentes();
        Console.WriteLine("Boas Vindas ao ByteBank Atendimento.!");

        string enderecoArquivo = "contas.txt";

        using (FileStream fluxoDeArquivo = new(enderecoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var linha = leitor.ReadLine();

            //var texto = leitor.ReadToEnd()

            //var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                ContaCorrente conta = ConverteStringParaContaCorrente(linha);
                _listaDeContas.Adicionar(conta);
                //Console.WriteLine(conta.ToString());
            }

            //new Atendimento().AtendimentoCliente();
        }

    }
}