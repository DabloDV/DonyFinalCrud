using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudFinal.WEB.Models.Entities
{
    public class RolUsuario
    {
        [Key]
        public int RolId { get; set; }
        [Column("Rol", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
    }
}
