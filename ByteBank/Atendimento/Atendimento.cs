using ByteBank.Exceptions;
using ByteBank_Modelos.Models.ADM.Conta;
using Newtonsoft.Json;

namespace ByteBank.Atendimento;

#nullable disable
internal class Atendimento
{

    private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>();

    public void AtendimentoCliente(List<ContaCorrente> listaDeContas)
    {
        try
        {
            _listaDeContas = listaDeContas;
            char opcao = '0';
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       Atendimento       ===");
                Console.WriteLine("===1 - Cadastrar Conta      ===");
                Console.WriteLine("===2 - Listar Contas        ===");
                Console.WriteLine("===3 - Remover Conta        ===");
                Console.WriteLine("===4 - Ordenar Contas       ===");
                Console.WriteLine("===5 - Pesquisar Conta      ===");
                Console.WriteLine("===6 - Exportar Contas      ===");
                Console.WriteLine("===7 - Sair do Sistema      ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");
                try
                {
                    opcao = Console.ReadLine()[0];
                }
                catch (Exception excecao)
                {
                    throw new ByteBankException(excecao.Message);
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverConta();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        PesquisarConta();
                        break;
                    case '6':
                        ExportarContas();
                        break;
                    case '7':
                        EncerrarAplicacao();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }
        catch (ByteBankException excecao)
        {
            Console.WriteLine($"{excecao.Message}");
        }
    }

    private void EncerrarAplicacao()
    {
        Console.WriteLine("Encerando a aplicação");
        Console.ReadKey();
    }

    private void ExportarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      EXPORTAR CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não é possivel realizar a exportação.");
            Console.ReadKey();
        }
        else
        {
            string json = JsonConvert.SerializeObject(_listaDeContas, Formatting.Indented);
            try
            {
                FileStream fs = new("contas.json", FileMode.Create);
                using (StreamWriter sw = new(fs))
                {
                    sw.WriteLine(json);
                }
                Console.WriteLine(@"Arquivo salvo");

            }
            catch (Exception e)
            {
                throw new ByteBankException(e.Message);
                Console.ReadKey();
            }
        }
    }

    void PesquisarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      PESQUISAR CONTA    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR (3)AGENCIA? ");
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                {
                    Console.Write("Informe o número da Conta: ");
                    string _numeroConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.Write("Informe o CPF do Titular: ");
                    string _cpf = Console.ReadLine();
                    ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                    break;
                }
            case 3:
                {
                    Console.Write("Informe o nomero da agencia: ");
                    int agencia = int.Parse(Console.ReadLine());
                    List<ContaCorrente> consultaAgencia = ConsultaPorAgencia(agencia);
                    ExibirListaDeContas(consultaAgencia);
                    Console.ReadKey();
                    break;
                }
            default:
                Console.WriteLine("Opção não implementada.");
                break;
        }

    }

    void ExibirListaDeContas(List<ContaCorrente> consultaAgencia)
    {
        if (consultaAgencia is not null)
            foreach (var conta in consultaAgencia)
                Console.WriteLine(conta.ToString());
        else
            Console.WriteLine("Consulta não retornou dados");
    }

    List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
    {
        var consulta = (
            from conta in _listaDeContas
            where conta.Numero_agencia == numeroAgencia
            select conta).ToList();
        return consulta;
    }

    ContaCorrente ConsultaPorCPFTitular(string? cpf)
    {
        return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    }

    ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
    {
        return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
    }

    void OrdenarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      ORDENAR CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        _listaDeContas.Sort();
        Console.WriteLine("Lista de contas ordenadas.");
        Console.ReadKey();
    }

    void RemoverConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===      REMOVER CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da Conta: ");
        string numeroConta = Console.ReadLine();
        ContaCorrente conta = null;
        foreach (ContaCorrente item in _listaDeContas)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
            }
        }
        if (conta != null)
        {
            _listaDeContas.Remove(conta);
            Console.WriteLine("... Conta removida da lista! ...");
        }
        else
        {
            Console.WriteLine(" ... Conta para remoção não encontrada ...");
        }
        Console.ReadKey();
    }

    void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===     LISTA DE CONTAS     ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");

        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não há contas cadastradas! ...");
            Console.ReadKey();
            return;
        }

        foreach (ContaCorrente item in _listaDeContas)
        {
            Console.WriteLine("===  Dados da Conta  ===");
            Console.WriteLine("Número da Conta : " + item.Conta);
            Console.WriteLine("Saldo da Conta : " + item.Saldo);
            Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
            Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
            Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===   CADASTRO DE CONTAS    ===");
        Console.WriteLine("===============================");
        Console.WriteLine("\n");
        Console.WriteLine("=== Informe dados da conta ===");

        Console.Write("Número da Agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());

        ContaCorrente conta = new ContaCorrente(numeroAgencia);

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Infome nome do Titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Infome CPF do Titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Infome Profissão do Titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }



}
