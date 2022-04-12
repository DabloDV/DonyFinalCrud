
using CrudFinal.WEB.Clases;
using CrudFinal.WEB.Models.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CrudFinal.WEB.Models.Abstract;
using System;
using CrudFinal.WEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudFinal.WEB.Models.Business
{
    public class UsuarioBusiness:IUsuarioBusiness
    {

        private readonly AppDbContext _context;
        public UsuarioBusiness(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerUsuariosTodos()
        {

            await using (_context)
            {
                IEnumerable<UsuarioDto> listaUsuarioDetalles =
                (from usuario in _context.Usuarios
                 join rol in _context.RolUsuarios
                 on usuario.RolId equals
                 rol.RolId
                 select new UsuarioDto
                 {
                     IdUsuario = usuario.IdUsuario,
                     Nombre = usuario.Nombre,
                     Rol = rol.Nombre,
                     Telefono = usuario.Telefono,
                     Documento = usuario.Documento

                 }).ToList();
                return listaUsuarioDetalles;
            }
        }


       

        public async Task<UsuarioGuardarDto> ObtenerUsuarioPorId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var usuario = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (usuario != null)
            {
                UsuarioGuardarDto usuarioGuardarDto = new()
                {
                    Nombre = usuario.Nombre,
                    IdUsuario = usuario.IdUsuario,
                    Rol = usuario.RolId,
                    Documento = usuario.Documento,
                    Telefono = usuario.Telefono
                };
                return usuarioGuardarDto;
            }
            return null;

        }

        public async Task<UsuarioDto> ObtenerUsuarioDtoPorId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var usuario = await _context.Usuarios.AsNoTracking().Include(x => x.Rol).FirstOrDefaultAsync(x => x.IdUsuario == id);

            if (usuario != null)
            {
                UsuarioDto usuarioDto = new()
                {
                    Nombre = usuario.Nombre,
                    IdUsuario = usuario.IdUsuario,
                    Rol = usuario.Rol.Nombre,
                    Documento = usuario.Documento,
                    Telefono = usuario.Telefono
                };
                return usuarioDto;
            }
            return null;

        }

        public void GuardarUsuario(UsuarioGuardarDto usuarioGuardarDto)
        {
            if (usuarioGuardarDto == null)
            {
                throw new ArgumentNullException(nameof(usuarioGuardarDto));
            }
            Usuario usuario = new()
            {
                Nombre = usuarioGuardarDto.Nombre,
                Documento = usuarioGuardarDto.Documento,
                Telefono = usuarioGuardarDto.Telefono,
                RolId = usuarioGuardarDto.Rol,
                IdUsuario = usuarioGuardarDto.IdUsuario

            };
            _context.Add(usuario);
        }


       

        public void EditarUsuario(UsuarioGuardarDto usuarioGuardarDto)
        {
            if (usuarioGuardarDto == null)
            {
                throw new ArgumentNullException(nameof(usuarioGuardarDto));
            }
            Usuario usuario = new()
            {
                Nombre = usuarioGuardarDto.Nombre,
                Documento = usuarioGuardarDto.Documento,
                Telefono = usuarioGuardarDto.Telefono,
                RolId = usuarioGuardarDto.Rol,
                IdUsuario = usuarioGuardarDto.IdUsuario

            };
            _context.Update(usuario);
        }

        public void EliminarUsuario(UsuarioGuardarDto usuarioGuardarDto)
        {
            if (usuarioGuardarDto == null)
            {
                throw new ArgumentNullException(nameof(usuarioGuardarDto));
            }
            Usuario usuario = new()
            {
                Nombre = usuarioGuardarDto.Nombre,
                Documento = usuarioGuardarDto.Documento,
                Telefono = usuarioGuardarDto.Telefono,
                RolId = usuarioGuardarDto.Rol,
                IdUsuario = usuarioGuardarDto.IdUsuario

            };
            _context.Remove(usuario);
        }

        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

       
    }

}