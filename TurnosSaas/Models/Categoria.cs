using System.ComponentModel.DataAnnotations;
namespace TurnosSaas.Models
{
    public class Categoria
    {
        public Categoria() { 
            Productos = new List<Producto>();
        }
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(1000)]
        public string Descripcion {  get; set; } = null!;
        public ICollection<Producto> Productos { get; set; } = null!;
    }
}
