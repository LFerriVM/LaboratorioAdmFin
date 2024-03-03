using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace admfin.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public EnumTipo Tipo { get; set; }
    public double Valor { get; set; }
    [ForeignKey("Balanco")]
    public int FkBalanco { get; set; }
    public Balanco Balanco { get; set; }

    public Item()
    {

    }

    public Item(string nome, EnumTipo enumTipo, double valor, int balancoId)
    {
        Nome = nome;
        Tipo = enumTipo;
        Valor = valor;
        FkBalanco = balancoId;
    }
}