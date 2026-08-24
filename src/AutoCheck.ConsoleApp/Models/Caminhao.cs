namespace AutoCheckConsole
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; private set; }
        public double CapacidadeCargaToneladas { get; private set; }

        public Caminhao(string marca, string modelo, int ano, int quilometragem, List<ItemVistoria> vistoriaRealizada,
            int quantidadeEixos, double capacidadeCargaToneladas)
            : base(marca, modelo, ano, quilometragem, vistoriaRealizada)
        {
            this.QuantidadeEixos = quantidadeEixos;
            this.CapacidadeCargaToneladas = capacidadeCargaToneladas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            List<string> checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Tacógrafo");
            checklist.Add("Sistema de Freios a Ar");
            checklist.Add("Trava e Lona da Caçamba");
            return checklist;
        }

        public override string ObterTipo()
        {
            return "Caminhão";
        }
    }
}