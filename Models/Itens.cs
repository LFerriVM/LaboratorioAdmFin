using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class Itens
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo{ get; set; }

}