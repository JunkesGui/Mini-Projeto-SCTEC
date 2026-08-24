namespace AutoCheckConsole
{
    public class Carro : Veiculo
    {
        private int QuantidadedePortas {get; set;}

        public Carro(string Marca, string Modelo, int Ano, int Quilometragem, List<ItemVistoria> VistoriaRealizada, int QuantidadedePortas) : base(Marca, Modelo, Ano, Quilometragem, VistoriaRealizada)
        {
            this.QuantidadedePortas = QuantidadedePortas;
        }

        public List<string> ObterChecklistObrigatório()
        {
            return ["Estepe", "Extintor", "Freios"];
        }
    }
}