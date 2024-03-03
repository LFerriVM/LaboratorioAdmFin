using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace admfin.Models;

public class Balanco
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; }
    public double? Valor { get; set; }
    public List<Item> Itens { get; set; }

    public Balanco(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;
        Itens = [];
    }

    public void InserirItem(Item item)
    {
        Itens.Add(item);
    }

    public void AlterarItem(string nomeItem, double valorItem)
    {
        try
        {
            Itens.Where(i => i.Nome == nomeItem).FirstOrDefault().Valor = valorItem;
        }
        catch (Exception)
        {
            Console.WriteLine("Item inexistente");
        }
    }

    public void RemoverItem(string nomeItem)
    {
        try
        {
            var teste = Itens.Where(i => i.Nome == nomeItem).FirstOrDefault() ?? throw new Exception("Item inexistente");
            Itens.Remove(teste);
        }
        catch (Exception)
        {
            Console.WriteLine("Item inexistente");
        }
    }

}