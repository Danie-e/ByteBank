using ByteBank_GeradorDePix;
using ByteBank_Modelos.Models.ADM.Conta;
using ByteBank_Modelos.Models.ADM.Funcionarios;

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
        //new Atendimento().AtendimentoCliente(_listaDeContas);

        Console.WriteLine(GeradorPix.GetChavePix());
        List<string> listaChaves = GeradorPix.GetChavesPix(5);
        foreach (var chave in listaChaves)
        {
            Console.WriteLine(chave);

        }
    }

    public class Estagiario : Funcionario
    {
        public Estagiario(double salario, string cpf) : base(salario, cpf)
        {
        }

        public override void AumentarSalario()
        {
            throw new NotImplementedException();
        }

        protected override double getBonificacao()
        {
            throw new NotImplementedException();
        }
    }
}