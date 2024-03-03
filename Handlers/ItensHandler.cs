using Data;
using Models;

namespace Handlers;

public class ItensHandler
{
    private DataContext _db;

    public ItensHandler(DataContext db)
    {
        _db = db;
    }

    public ItensHandler(){

    }

    void InserirItem()
    {

        _db.SaveChanges();
    }

    void AlterarItem() { }

    void RemoverItem() { }

    void SalvarItem() { }
    public static void MenuItens()
    {
        var itens = new ItensHandler();
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