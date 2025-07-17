using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        string caminhoDoArquivo = "contasExportadas.csv";

        using (FileStream fluxoArquivo = new(caminhoDoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoArquivo))
        {
            for (int i = 0; i < 100000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); //Despeja o buffer para o Stream

                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }

    static void EscritaBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);           //número da Agência
            escritor.Write(546544);   //número da conta
            escritor.Write(4000.50); //Saldo
            escritor.Write("Gustavo Braga");
        }
    }
}

