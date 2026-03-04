using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostLocal.API.Models;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("CategoriaId")]
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(3000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatório")]
    [Display(Name = "Quantidade")]
    public int Qtde { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor")]
    [Required(ErrorMessage = "O Valor é obrigatório")]
    public decimal ValorCusto { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }
}