namespace AutoCheckConsole
{
    public class Caminhao : Veiculo
    {
        private int QuantidadedeEixos {get; set;}
        public Caminhao(string Marca, string Modelo, int Ano, int Quilometragem, List<ItemVistoria> VistoriaRealizada, int QuantidadedeEixos) : base(Marca, Modelo, Ano, Quilometragem, VistoriaRealizada)
        {
            this.QuantidadedeEixos = QuantidadedeEixos;
        }
        public List<string> ObterChecklistObrigatório()
        {
            return ["Sistem hidraulico", "Lona da Caçamba"];
        }
    }
}