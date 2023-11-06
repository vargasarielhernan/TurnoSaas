using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosSaas.Models
{
    public class Detalle_Pedido
    {
        [Key]
        public int DetallePedido { get; set;}
        [Required]
        public int PedidoId { get; set;}
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; } = null!;
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
