using ByteBank_Modelos.Models.ADM.SistemaInterno;
using ByteBank_Modelos.Models.ADM.Utilitario;

namespace ByteBank_Modelos.Models.ADM.ParceriaComercial;

public class ParceiroComercial : IAutenticavel
{
    public string Senha { get; set; }
    internal AutenticacaoUtil Autenticador { get; set; }

    public bool Autenticar(string senha)
    {
        return Autenticador.ValidarSenha(this.Senha, senha);
    }
}
