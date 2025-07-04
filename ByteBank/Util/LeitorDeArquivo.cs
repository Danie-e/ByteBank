using System.Text;

namespace ByteBank.Util;

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
}