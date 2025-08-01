namespace ByteBank_GeradorDePix
{
    public static class GeradorPix
    {
        public static string GetChavePix()
        {
            return Guid.NewGuid().ToString();
        }

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
