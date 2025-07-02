using ByteBank.Atendimento;
using ByteBank.Modelos.Conta;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Boas Vindas ao ByteBank Atendimento.!");

        string enderecoArquivo = "contas.txt";
        FileStream fluxoArquivo = new(enderecoArquivo, FileMode.Open);

        int numeroDeBytesLidos = -1;
        var buffer = new byte[1024]; //1kb

        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, buffer.Length);
            EscreverBuffer(buffer);
        }

        //        List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        //{
        //    new ContaCorrente(95) {Saldo=100,Titular=new(){Nome="Daniela",Profissao="Dev",Cpf="123456789" } },
        //    new ContaCorrente(95) {Saldo=200,Titular=new(){Nome="Julio",Profissao="Tester",Cpf="789456123" }},
        //    new ContaCorrente(94) {Saldo=60,Titular=new(){Nome="Isabela",Profissao="Desiner",Cpf="741258963" }}
        //};
        //        new Atendimento().AtendimentoCliente();
    }

    static public void EscreverBuffer(byte[] buffer)
    {
        foreach (byte item in buffer)
        {
            Console.Write(item);
        }
    }
}