using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DigitalCursosWeb.Service
{
    public class UsuarioService : IUsuarioService
    {
        public HttpClient _httpClient;
        public UsuarioService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var Usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Usuario>>("api/Usuarios");

            return Usuarios;
        }
        public async Task<Usuario> GetUsuario(int id)
        {
            var Usuario = await _httpClient.GetFromJsonAsync<Usuario>($"api/Usuarios/{id}");

            return Usuario;
        }

        public async Task<Usuario> CreateUsuario(Usuario novoUsuario)
        {
            var response = await _httpClient.PostAsJsonAsync<Usuario>($"api/Usuarios", novoUsuario);
            var content = await response.Content.ReadFromJsonAsync<Usuario>();

            return content;
        }

        public async Task<Usuario> UpdateUsuario(Usuario Usuario)
        {
            var response = await _httpClient.PutAsJsonAsync<Usuario>($"api/Usuarios/{Usuario.Id}", Usuario);
            var content = await response.Content.ReadFromJsonAsync<Usuario>();

            return content;
        }
        public async Task DeleteUsuario(int IdUsuario)
        {
            await _httpClient.DeleteAsync($"api/Usuarios/{IdUsuario}");
        }
    }
}
