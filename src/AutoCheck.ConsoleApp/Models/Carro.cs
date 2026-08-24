namespace AutoCheckConsole
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas { get; private set; }

        public Carro(string marca, string modelo, int ano, int quilometragem, List<ItemVistoria> vistoriaRealizada, int quantidadePortas)
            : base(marca, modelo, ano, quilometragem, vistoriaRealizada)
        {
            this.QuantidadePortas = quantidadePortas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            List<string> checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Estepe e Macaco");
            checklist.Add("Triângulo de Sinalização");
            checklist.Add("Ar Condicionado Funcional");
            return checklist;
        }

        public override string ObterTipo()
        {
            return "Carro";
        }

        public override string ObterDadosEspecificos()
        {
            return $"Quantidade de Portas: {this.QuantidadePortas}";
        }
    }
}