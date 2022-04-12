using System.ComponentModel.DataAnnotations;

namespace CrudFinal.WEB.Clases
{
    public class RolDto
    {
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Rol { get; set; }
    }
}
