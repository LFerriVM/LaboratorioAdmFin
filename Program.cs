// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Threading.Tasks.Dataflow;
using Data;
using Models;

var db = new DataContext();

// var connection = new SqliteConnection("Data Source=hello.db");
// Area de Execucao Comum
System.Console.WriteLine("Insira o nome do arquivo a ser utilizado:");
string nomeArquivo = Console.ReadLine();
List<string> itens = [];
menu();
// Fim Area de Execucao Comum


void InserirItem()
{   
    db.Add(new Itens { Nome = "aaaaa", Valor = 4125.15 });
    db.SaveChanges();
}

void AlterarItem() { }

void RemoverItem() { }

void SalvarItem() { }

void menu()
{
    System.Console.WriteLine(
        "###########################\n" +
        "## 1 - Inserir Item      ##\n" +
        "## 2 - Alterar Item      ##\n" +
        "## 3 - Remover Item      ##\n" +
        "## 4 - Salvar Arquivo    ##\n" +
        "## 5 - Fechar            ##\n" +
        "###########################");
    int selector = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine(nomeArquivo);
    switch (selector)
    {
        case 1:
            InserirItem();
            break;
        case 2:
            AlterarItem();
            break;
        case 3:
            RemoverItem();
            break;
        case 4:
            SalvarItem();
            break;
        case 5:
            Environment.Exit(0);
            break;
        default:
            Console.Clear();
            menu();
            break;
    }
}