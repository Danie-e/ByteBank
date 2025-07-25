namespace ByteBank_Modelos.Models.ADM.Utilitario;

internal class AutenticacaoUtil
{
    public bool ValidarSenha(string senhaVerdadeira, string senhaTentativa)
    {
        return senhaVerdadeira.Equals(senhaTentativa);
    }
}
