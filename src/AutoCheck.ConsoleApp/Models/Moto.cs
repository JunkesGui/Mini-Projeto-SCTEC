namespace AutoCheckConsole
{
    public class Moto : Veiculo
    {
        public int Cilindradas { get; private set; }
        public Moto(string marca, string modelo, int ano, int quilometragem, List<ItemVistoria> vistoriaRealizada, int cilindradas)
            : base(marca, modelo, ano, quilometragem, vistoriaRealizada)
        {
            this.Cilindradas = cilindradas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            List<string> checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Kit Transmissão/Corrente");
            checklist.Add("Manetes de Freio/Embreagem");
            checklist.Add("Pezinho Lateral");
            return checklist;
        }

        public override string ObterTipo()
        {
            return "Moto";
        }
    }
}