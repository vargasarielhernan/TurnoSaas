using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosSaas.Models
{
    public class Detalle_Turno
    {
        [Key]
        public int DetalleTurno { get; set;}
        [Required]
        public int TurnoId { get; set;}
        [ForeignKey("PedidoId")]
        public Turno Turno { get; set; } = null!;
        [Required]
        public int ProductoId { get; set; }
        [ForeignKey("PeoductoId")]
        public Producto Producto { get; set; } = null!;
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
