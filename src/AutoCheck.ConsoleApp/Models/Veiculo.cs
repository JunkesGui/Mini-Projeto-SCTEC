abstract class Veiculo{
    private string Marca;
    private string Modelo;
    private int Ano;
    private int Quilometragem;
    private List<ItemVistoria> VistoriaRealizada;

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
        return ["Nível de óleo", "Documentação", "Extintor", "Calibração dos Pneus", "Sistema Elétrico"];
    } 
}