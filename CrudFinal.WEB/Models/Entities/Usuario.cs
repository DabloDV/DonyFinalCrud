using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudFinal.WEB.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario{ get; set; }

        [DisplayName("Nombre Completo")]
        [Column("NombreUsuario", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }
        public int Documento { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Telefono { get; set; }

        public int RolId { get; set; }
        public virtual RolUsuario Rol { get; set; }

  
    }
}
