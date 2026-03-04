using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostLocal.API.Models;

    public class Categoria
{
    [Key]
    public int Id { get; set; }
    public int CategoriaId { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    [StringLength(26)]
    public string Cor { get; set; } = "rgba(0,0,0,1)";

}