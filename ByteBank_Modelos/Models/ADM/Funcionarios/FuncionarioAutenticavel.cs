using ByteBank_Modelos.Models.ADM.SistemaInterno;
using ByteBank_Modelos.Models.ADM.Utilitario;


namespace ByteBank_Modelos.Models.ADM.Funcionarios;

public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
{
    public string Senha { get; set; }
    internal AutenticacaoUtil Autenticador { get; set; }

    public FuncionarioAutenticavel(double salario, string cpf)
        : base(salario, cpf)
    {

    }

    public bool Autenticar(string senha)
    {
        return Autenticador.ValidarSenha(this.Senha, senha);

    }
}
