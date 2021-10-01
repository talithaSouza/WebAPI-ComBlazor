using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalUsuariosWeb.Service
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        public Task<Usuario> GetUsuario(int ID);
        public Task<Usuario> CreateUsuario(Usuario Usuario);
        public Task<Usuario> UpdateUsuario(Usuario Usuario);
        public Task DeleteUsuario(int ID);
    }
}
