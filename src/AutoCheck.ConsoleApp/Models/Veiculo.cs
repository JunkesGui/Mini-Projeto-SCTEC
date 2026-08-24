namespace AutoCheckConsole
{
    public abstract class Veiculo
    {
        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }
        public int Ano { get; protected set; }
        public int Quilometragem { get; protected set; }
        public List<ItemVistoria> VistoriaRealizada { get; protected set; }

        public Veiculo(string marca, string modelo, int ano, int quilometragem, List<ItemVistoria> vistoriaRealizada)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Quilometragem = quilometragem;
            this.VistoriaRealizada = vistoriaRealizada;
        }

        public void AdicionarItemVistoriado(string nome, string status)
        {
            ItemVistoria item = new ItemVistoria(nome, status);
            this.VistoriaRealizada.Add(item);
        }

        public virtual List<string> ObterChecklistObrigatorio()
        {
            return new List<string>
            {
                "Nível de Óleo do Motor",
                "Bateria e Sistema Elétrico",
                "Documentação Regularizada"
            };
        }

        public virtual string ObterTipo()
        {
            return "Veículo";
        }

        public virtual string ObterDadosEspecificos()
        {
            return string.Empty;
        }
    }
}