using CrudFinal.WEB.Clases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudFinal.WEB.Models.Abstract
{
    public interface IUsuarioBusiness
    {
        Task<IEnumerable<UsuarioDto>> ObtenerUsuariosTodos();
        void GuardarUsuario(UsuarioGuardarDto usuarioGuardarDto);
        Task<UsuarioGuardarDto> ObtenerUsuarioPorId(int? id);
        void EditarUsuario(UsuarioGuardarDto usuarioGuardarDto);
        Task<bool> GuardarCambios();
        Task<UsuarioDto> ObtenerUsuarioDtoPorId(int? id);
        void EliminarUsuario(UsuarioGuardarDto usuarioGuardarDto);
    }
}
