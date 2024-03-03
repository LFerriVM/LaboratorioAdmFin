using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class Balancos
{
    [Key]
    public int Id { get; set; }
    public DateOnly DataCriacao { get; set; }
    public double Valor { get; set; }

}