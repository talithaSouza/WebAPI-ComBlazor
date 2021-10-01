using DigitalCursos.Models.Models;
using DigitalUsuariosWeb.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;

namespace DigitalCursosWeb.Service
{
    public class UsuarioService : IUsuarioService
    {
        public HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Usuario> CreateUsuario(Usuario Usuario)
        {
            var addUsuario = await _httpClient.PutAsJsonAsync<Usuario>($"api/usuario", Usuario);
            var content = await addUsuario.Content.ReadFromJsonAsync<Usuario>();
            return content;
        }

        public Task DeleteUsuario(int ID)
        {
            return _httpClient.DeleteAsync($"api/usuario/{ID}");
        }

        public async Task<Usuario> GetUsuario(int ID)
            => await _httpClient.GetFromJsonAsync<Usuario>($"api/usuario/{ID}");
        

        public async Task<IEnumerable<Usuario>> GetUsuarios()
            => await _httpClient.GetFromJsonAsync<IEnumerable<Usuario>>("api/usuario");


        public async Task<Usuario> UpdateUsuario(Usuario Usuario)
        {
            var updateUsuario = await _httpClient.PostAsJsonAsync<Usuario>($"api/usuario/{Usuario.Id}", Usuario);
            var content = await updateUsuario.Content.ReadFromJsonAsync<Usuario>();
            return content;
        }
    }
}
