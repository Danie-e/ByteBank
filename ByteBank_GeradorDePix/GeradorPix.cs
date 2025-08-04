namespace ByteBank_GeradorDePix
{
    /// <summary>
    /// Classe para gerar chaves pix usando o formato Guid. 
    /// </summary>
    /// <returns></returns>
    public static class GeradorPix
    {
        /// <summary>
        /// Método para gerar uma chave aleatória pix usando o formato Guid. 
        /// </summary>
        /// <returns>Retorna uma chave pux no formato string</returns>
        public static string GetChavePix()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Método para gerar chaves pix de acordo com a quantidade passada no parâmetro usando o formato Guid. 
        /// </summary>
        /// <param name="numeroDeChaves">Quantidade de chaves a serem geradas</param>
        /// <returns>Lista de chaves no formato string</returns>
        public static List<string> GetChavesPix(int numeroDeChaves)
        {
            if (numeroDeChaves <= 0)
                return null;
            else
            {
                List<string> chaves = new();
                for (int i = 0; i < numeroDeChaves; i++)
                    chaves.Add(Guid.NewGuid().ToString());
                return chaves;
            }
        }
    }
}
