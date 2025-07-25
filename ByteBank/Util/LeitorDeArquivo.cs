using ByteBank_Modelos.Models.ADM.Conta;
using System.Text;

partial class Program
{
    static public void LerArquivoTexto(string enderecoArquivo)
    {
        using (FileStream fluxoArquivo = new(enderecoArquivo, FileMode.Open))
        {
            int numeroDeBytesLidos = -1;
            var buffer = new byte[1024]; //1kb

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoArquivo.Read(buffer, 0, buffer.Length);
                EscreverBuffer(buffer);
            }
        }
    }

    static public void EscreverBuffer(byte[] buffer)
    {
        var utf8 = new UTF8Encoding();
        string texto = utf8.GetString(buffer);
        Console.Write(texto);
    }

    static ContaCorrente ConverteStringParaContaCorrente(string linha)
    {
        string[] campos = linha.Split(',');
        ContaCorrente conta = new(int.Parse(campos[0]))
        {
            Saldo = double.Parse(campos[2].Replace('.', ',')),
            Titular = new() { Nome = campos[3] }
        };
        return conta;
    }

    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            Int32 agencia = leitor.ReadInt32();
            Int32 numeroDaConta = leitor.ReadInt32();
            double saldo = leitor.ReadDouble();
            string titular = leitor.ReadString();

            Console.WriteLine($@"Agencia: {agencia}
Numero da conta: {numeroDaConta}
Saldo: {saldo}
Titular: {titular}");
        }
    }

    static void UsarStreamDeEntrada()
    {
        {
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024]; //1kb

                while (true)
                {
                    var byteslidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    fs.Write(buffer, 0, byteslidos);
                    fs.Flush();

                    Console.WriteLine($"Bytes lidos na console: {byteslidos}");
                }
            }
        }
    }

}