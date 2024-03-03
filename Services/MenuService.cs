using admfin.Models;
using Data;

namespace admfin.Services;

public class MenuService
{
    private string filePath = "./Arquivos/";
    private ItensService _itensService;
    private DataContext _db;
    public MenuService(ItensService itensService,
                        DataContext dataContext)
    {
        _itensService = itensService;
        _db = dataContext;
    }

    public void Menu()
    {
        Console.WriteLine(
            "###########################\n" +
            "## 1 - Itens             ##\n" +
            "## 2 - Balanços          ##\n" +
            "###########################\n" +
            "## 0 - Fechar            ##\n" +
            "###########################");
        int selector = Convert.ToInt32(Console.ReadLine());
        switch (selector)
        {
            case 1:
                _itensService.MenuItens();
                break;
            case 2:
                MenuBalanco();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Menu();
                break;
        }
    }

    public void MenuBalanco()
    {

        Console.WriteLine(
                "################################\n" +
                "## 1 - Criar novo balanço     ##\n" +
                "## 2 - Abrir balanço          ##\n" +
                "################################\n" +
                "## 0 - Fechar                 ##\n" +
                "#################################");
        int selector = Convert.ToInt32(Console.ReadLine());
        switch (selector)
        {
            case 1:
                CriarBalanco();
                break;
            case 2:
                AbrirBalanco();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                MenuBalanco();
                break;
        }

    }

    private void AbrirBalanco()
    {
        Console.WriteLine("Digite o nome do arquivo");
        string nomeBalanco = Console.ReadLine().ToLower();
        try
        {
            Balanco balanco = _db.Balancos.FirstOrDefault(b => b.Nome.ToLower() == nomeBalanco);
            if (balanco == null)
            {
                balanco = new Balanco(nomeBalanco);
                _db.Balancos.Add(balanco);
                _db.SaveChanges();
            }
            string[] conteudo = File.ReadAllLines(filePath + nomeBalanco + ".txt");
            List<Item> listaItens = new List<Item>();
            foreach (var line in conteudo)
            {
                Item item = LerItemBalanco(line, balanco.Id);
                listaItens.Add(item);
            }
            balanco.Itens.AddRange(listaItens);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: ");
            Console.WriteLine(ex.Message);
            MenuBalanco();
        }
    }

    private Item LerItemBalanco(string linha, int balancoId)
    {
        string tipo = linha.Substring(0, linha.IndexOf(' ')).ToLower();
        if (string.IsNullOrEmpty(tipo) || tipo == "total") return null;
        EnumTipo enumTipo;
        switch (tipo)
        {
            case "ac":
                enumTipo = EnumTipo.AC;
                break;
            case "anc":
                enumTipo = EnumTipo.ANC;
                break;
            case "pc":
                enumTipo = EnumTipo.PC;
                break;
            case "pnc":
                enumTipo = EnumTipo.PNC;
                break;
            case "pl":
                enumTipo = EnumTipo.PL;
                break;
            default:
                throw new Exception("Existem tipos inválidos no arquivo. ");
                break;
        }
        string nomeItem = linha.Substring(linha.IndexOf(' '), linha.LastIndexOf(' '));
        int index1 = linha.LastIndexOf(' ');
        string valorTexto = linha.Substring(index1, linha.Length - index1);
        double valor = Convert.ToDouble(valorTexto);

        return new Item(nomeItem, enumTipo, valor, balancoId);
    }

    private void CriarBalanco()
    {
        Console.WriteLine("Digite o nome do novo balanço");
        string nomeBalanco = Console.ReadLine();
    }
}