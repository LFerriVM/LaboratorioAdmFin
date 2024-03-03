using System.Globalization;
using System.Security.Principal;
using admfin.Models;

namespace admfin.Services;

public class ItensService
{
    private readonly string filePath = "./Arquivos/";
    public ItensService()
    {

    }

    public void InserirItem(Balanco balanco)
    {
        Console.WriteLine("Digite o nome do item");
        string nomeItem = Console.ReadLine();
        Console.WriteLine("Digite o tipo do item");
        string tipoItem = Console.ReadLine().ToLower();
        var enumTipo = tipoItem switch
        {
            "ac" => EnumTipo.AC,
            "anc" => EnumTipo.ANC,
            "pc" => EnumTipo.PC,
            "pnc" => EnumTipo.PNC,
            "pl" => EnumTipo.PL,
            _ => throw new Exception("Tipo Invalido."),
        };
        Console.WriteLine("Digite o valor do item");
        double valorItem = Convert.ToDouble(Console.ReadLine().Trim(), CultureInfo.CreateSpecificCulture("en-US"));
        balanco.InserirItem(new Item(nomeItem, enumTipo, valorItem));
        MenuItens(balanco);
    }

    public void AlterarItem(Balanco balanco)
    {

        Console.WriteLine("Digite o nome do item que deseja alterar: ");
        string nomeItem = Console.ReadLine();
        Console.WriteLine("Digite o novo valor do item: ");
        string valorTexto = Console.ReadLine();
        double valor = Convert.ToDouble(valorTexto.Replace(',', '.').Trim(), CultureInfo.CreateSpecificCulture("en-US"));
        balanco.AlterarItem(nomeItem, valor);
        MenuItens(balanco);
    }

    public void RemoverItem(Balanco balanco)
    {
        Console.WriteLine("Digite o nome do item que deseja remover: ");
        string nomeItem = Console.ReadLine();
        balanco.RemoverItem(nomeItem);
        MenuItens(balanco);
    }

    public void SalvarArquivo(Balanco balanco)
    {
        List<Item> itens = [];
        itens.AddRange(balanco.Itens.Where(i => i.Tipo == EnumTipo.AC));
        itens.AddRange(balanco.Itens.Where(i => i.Tipo == EnumTipo.ANC));
        itens.AddRange(balanco.Itens.Where(i => i.Tipo == EnumTipo.PC));
        itens.AddRange(balanco.Itens.Where(i => i.Tipo == EnumTipo.PNC));
        itens.AddRange(balanco.Itens.Where(i => i.Tipo == EnumTipo.PL));

        double ativoTotal = 0;
        double passivoTotal = 0;

        System.Console.WriteLine("Digite o nome do arquivo:");
        string nomeArquivo = Console.ReadLine();

        using (StreamWriter sw = new(filePath + nomeArquivo + ".txt"))
        {
            foreach (Item item in itens)
            {
                sw.WriteLine($"{item.Tipo} {item.Nome} {NormalizarValores(item.Valor)}");
                if (item.Tipo is EnumTipo.AC or EnumTipo.ANC)
                {
                    ativoTotal += item.Valor;
                }
                else
                {
                    passivoTotal += item.Valor;
                }
            }
            sw.WriteLine();
            sw.WriteLine($"TOTAL ATIVO = {NormalizarValores(ativoTotal)}");
            sw.WriteLine($"TOTAL PASSIVO + PATRIMONIO LIQUIDO = {NormalizarValores(passivoTotal)}");
        }
    }
    public void MenuItens(Balanco balanco)
    {
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
                try
                {
                    InserirItem(balanco);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: \n{ex.Message}");
                    MenuItens(balanco);
                }
                break;
            case 2:
                try
                {
                    AlterarItem(balanco);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: \n{ex.Message}");
                    MenuItens(balanco);
                }
                break;
            case 3:
                try
                {
                    RemoverItem(balanco);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: \n{ex.Message}");
                    MenuItens(balanco);
                }
                break;
            case 4:
                try
                {
                    SalvarArquivo(balanco);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: \n{ex.Message}");
                    MenuItens(balanco);
                }
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                MenuItens(balanco);
                break;
        }
    }
    private static string NormalizarValores(double valor)
    {
        return $"{valor:n2}".Replace(".", "").Replace(",", ".").Trim();
    }
}