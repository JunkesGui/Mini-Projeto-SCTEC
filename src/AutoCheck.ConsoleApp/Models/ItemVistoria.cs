namespace AutoCheckConsole
{
    public class ItemVistoria
    {
        private static readonly string[] StatusValidos = { "Bom", "Regular", "Ruim" };
        public string Nome { get; }
        public string Status { get; }

        public ItemVistoria(string nome, string status)
        {
            bool statusValido = false;
            foreach (string statusPermitido in StatusValidos)
            {
                if (statusPermitido == status)
                {
                    statusValido = true;
                    break;
                }
            }

            if (!statusValido)
            {
                throw new ArgumentException(
                    $"Status inválido: '{status}'. Valores aceitos: \"Bom\", \"Regular\" ou \"Ruim\".",
                    nameof(status));
            }

            this.Nome = nome;
            this.Status = status;
        }
    }
}