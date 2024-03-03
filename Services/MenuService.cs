using System.Globalization;
using admfin.Models;

namespace admfin.Services;

public class MenuService(ItensService itensService)
{
    private readonly string filePath = "./Arquivos/";
    private readonly ItensService _itensService = itensService;

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
            Balanco balanco = new(nomeBalanco);

            string[] conteudo = File.ReadAllLines(filePath + nomeBalanco + ".txt");
            List<Item> listaItens = [];
            foreach (var line in conteudo)
            {
                Item item = LerItemBalanco(line);
                if (item == null) continue;
                listaItens.Add(item);
            }

            balanco.Itens = listaItens;

            _itensService.MenuItens(balanco);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: ");
            Console.WriteLine(ex.Message);
            MenuBalanco();
        }
    }

    private static Item LerItemBalanco(string linha)
    {
        if (string.IsNullOrEmpty(linha)) return null;
        string tipo = linha[..linha.IndexOf(' ')].ToLower();
        if (tipo == "total") return null;
        var enumTipo = tipo switch
        {
            "ac" => EnumTipo.AC,
            "anc" => EnumTipo.ANC,
            "pc" => EnumTipo.PC,
            "pnc" => EnumTipo.PNC,
            "pl" => EnumTipo.PL,
            _ => throw new Exception("Existem tipos inválidos no arquivo. "),
        };
        string nomeItem = linha.Substring(linha.IndexOf(' ') + 1, linha.LastIndexOf(' ') - linha.IndexOf(' ') - 1);
        string valorTexto = linha[linha.LastIndexOf(' ')..];
        double valor = Convert.ToDouble(valorTexto.Trim(), CultureInfo.CreateSpecificCulture("en-US"));

        return new Item(nomeItem, enumTipo, valor);
    }

    private void CriarBalanco(string nomeBalanco = "")
    {
        if (String.IsNullOrEmpty(nomeBalanco))
        {
            Console.WriteLine("Digite o nome do novo balanço");
            nomeBalanco = Console.ReadLine();
        }
        Balanco balanco = new(nomeBalanco);

        _itensService.MenuItens(balanco);
    }
}