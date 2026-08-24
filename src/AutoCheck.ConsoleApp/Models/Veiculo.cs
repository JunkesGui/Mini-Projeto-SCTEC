namespace AutoCheckConsole
{
    public abstract class Veiculo{
        protected string Marca {get; set;}
        protected string Modelo {get; set;}
        protected int Ano {get; set;}
        protected int Quilometragem {get; set;}
        protected List<ItemVistoria> VistoriaRealizada;

        public Veiculo(string Marca, string Modelo, int Ano, int Quilometragem, List<ItemVistoria> VistoriaRealizada)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Ano = Ano;
            this.Quilometragem = Quilometragem;
            this.VistoriaRealizada = VistoriaRealizada;
        }

        public void AdicionarItemVistoriado(string nome, string status)
        {
            
        }

        public virtual List<string> ObterChecklistObrigatorio()
        {
            return ["Nível de óleo", "Documentação", "Calibração dos Pneus", "Sistema Elétrico"];
        } 
    }
}