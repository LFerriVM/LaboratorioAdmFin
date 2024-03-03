using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

public class ItensBalancos
{
    [ForeignKey("Itens")]
    public int IdItem { get; set; }
    public Itens Itens { get; set; }

    [ForeignKey("Balancos")]
    public int IdBalanco { get; set; }
    public Balancos Balancos { get; set; }

    public double ValorItem { get; set; }

}