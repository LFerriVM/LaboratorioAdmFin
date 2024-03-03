using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace admfin.Models;

public class Balanco
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; }
    public double? Valor { get; set; }
    public List<Item> Itens { get; set; }

    public Balanco(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;
    }

}