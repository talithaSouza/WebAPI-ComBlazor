using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalCursosWeb.Service
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<Usuario>> GetUsuarios();
        public Task<Usuario> GetUsuario(int id);
        public Task<Usuario> CreateUsuario(Usuario Usuario);
        public Task<Usuario> UpdateUsuario(Usuario Usuario);
        public Task DeleteUsuario(int IdUsuario);
    }
}
