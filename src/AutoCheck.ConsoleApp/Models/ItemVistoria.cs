public class ItemVistoria
{
    private string Nome;
    private string Status;

    public ItemVistoria(string nome, string status)
    {
        Nome = nome;
        Status = status;
    }

    public string getNome()
    {
        string nome = Nome;
        return nome;
    }

    public string getStatus()
    {
        string status = Status;
        return status;
    }
}
