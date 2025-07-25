
using ByteBank_Modelos.Models.ADM.Funcionarios;

namespace ByteBank_Modelos.Models.ADM.Utilitario;

public class GerenciadorDeBonificacao
{
    private double _totalBonificacao;

    public void Registrar(Funcionario funcionario)
    {
        _totalBonificacao += funcionario.getBonificacao();
    }

    public double GetTotalBonificacao()
    {
        return _totalBonificacao;
    }

}
