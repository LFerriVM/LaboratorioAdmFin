using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace admfin.Models;

public class Item
{
    public string Nome { get; set; }
    public EnumTipo Tipo { get; set; }
    public double Valor { get; set; }

    public Item()
    {

    }

    public Item(string nome, EnumTipo enumTipo, double valor)
    {
        Nome = nome;
        Tipo = enumTipo;
        Valor = valor;
    }
}