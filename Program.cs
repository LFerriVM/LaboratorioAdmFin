// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Threading.Tasks.Dataflow;
using Data;
using Models;
using Handlers;

var db = new DataContext();

// var connection = new SqliteConnection("Data Source=hello.db");
// Area de Execucao Comum
System.Console.WriteLine("Insira o nome do arquivo a ser utilizado:");
string nomeArquivo = Console.ReadLine();
List<string> itens = [];
Menu();
// Fim Area de Execucao Comum




void Menu() { }

void MenuGeral()
{
    var itens = new ItensHandler();
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
            itens.MenuItens();
            break;
        case 2:
            MenuBalanco();
            break;
        case 0:
            Environment.Exit(0);
            break;
        default:
            Console.Clear();
            MenuGeral();
            break;
    }
}

void MenuBalanco()
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

