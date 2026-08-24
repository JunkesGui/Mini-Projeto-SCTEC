namespace AutoCheckConsole
{
    public class Moto : Veiculo
    {
        private int Cilindradas {get; set;}
        public Moto(string Marca, string Modelo, int Ano, int Quilometragem, List<ItemVistoria> VistoriaRealizada, int Cilindradas) : base(Marca, Modelo, Ano, Quilometragem, VistoriaRealizada)
        {
            this.Cilindradas = Cilindradas;
        }

        public List<string> ObterChecklistObrigatório()
        {
            return ["Corrente", "Embreagem"];
        }
    }
}