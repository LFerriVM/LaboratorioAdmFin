using Data;

namespace admfin.Services;

public class ItensService
{
    private DataContext _db;

    public ItensService(DataContext db)
    {
        _db = db;
    }

    public ItensService()
    {

    }

    void InserirItem()
    {

        _db.SaveChanges();
    }

    void AlterarItem() { }

    void RemoverItem() { }

    void SalvarItem() { }
    public void MenuItens()
    {
        var itens = new ItensService();
        Console.WriteLine(
            "###########################\n" +
            "## 1 - Inserir Item      ##\n" +
            "## 2 - Alterar Item      ##\n" +
            "## 3 - Remover Item      ##\n" +
            "## 4 - Salvar Arquivo    ##\n" +
            "###########################\n" +
            "## 0 - Fechar            ##\n" +
            "###########################");
        int selector = Convert.ToInt32(Console.ReadLine());
        switch (selector)
        {
            case 1:
                itens.InserirItem();
                break;
            case 2:
                itens.AlterarItem();
                break;
            case 3:
                itens.RemoverItem();
                break;
            case 4:
                itens.SalvarItem();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                MenuItens();
                break;
        }
    }
}