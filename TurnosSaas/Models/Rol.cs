using System.ComponentModel.DataAnnotations;
namespace TurnosSaas.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio")]
        [StringLength(50)]
        public string RolName { get; set; } = null!;
    }
}
