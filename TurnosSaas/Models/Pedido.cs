using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosSaas.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId {  get; set; }
        [Required]
        public int UsuarioId {  get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = null!;
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Estado { get; set; } = null!;
        public int DireccionIdSeleccionada {  get; set; }
        [ForeignKey("UsuarioId")]
        public Direccion Direccion { get; set; } = null!;
        public decimal Total { get; set; }
        public ICollection<Detalle_Pedido> DetallesPedido { get; set; } = null!;

    }
}
