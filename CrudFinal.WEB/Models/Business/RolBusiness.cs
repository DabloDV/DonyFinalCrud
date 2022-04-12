using Microsoft.EntityFrameworkCore;
using CrudFinal.WEB.Clases;
using CrudFinal.WEB.Models.Abstract;
using CrudFinal.WEB.Models.DAL;
using CrudFinal.WEB.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CrudFinal.WEB.Models.Business
{
    public class RolBusiness : IRolBusiness
    {
        private readonly AppDbContext _context;
        public RolBusiness(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<RolDto>> ObtenerListaRolesTodos()
        {
            List<RolUsuario> listaRoles = new();
            List<RolDto> ListaRolesDto = new();
            listaRoles = await _context.RolUsuarios.OrderBy(x => x.Nombre).ToListAsync();

            listaRoles.ForEach(c =>
            {
                RolDto rolDto = new()
                {
                    IdRol = c.RolId,
                    Rol = c.Nombre,

                };
                ListaRolesDto.Add(rolDto);
            });
            return ListaRolesDto;
        }

     
    }
}
