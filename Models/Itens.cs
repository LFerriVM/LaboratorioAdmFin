using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class Itens
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }

}