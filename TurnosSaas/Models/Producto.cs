using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosSaas.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId {  get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Imagen { get; set; } = null!;
        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriId")]
        public Categoria Categoria { get; set; }=null!;
        [Required]
        public int Stock { get; set; }
        [Required]
        public bool Activo { get; set;}
        public ICollection<Detalle_Pedido> DetallesPedido { get; set; } = null!;
    }
}
