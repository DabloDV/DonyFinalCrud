using CrudFinal.WEB.Clases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudFinal.WEB.Models.Abstract
{
    public interface IRolBusiness
    {
        Task<IEnumerable<RolDto>> ObtenerListaRolesTodos();
        
    }
}
