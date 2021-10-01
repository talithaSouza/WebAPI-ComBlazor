using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DigitalCursosWeb.Service
{
    public class CursoService : ICursoService
    {
        public HttpClient _httpClient;

        public CursoService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<IEnumerable<Curso>> GetCursos()
        {
            var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>("api/curso");

            return cursos;
        }
        public async Task<Curso> GetCurso(int ID)
        {
            var curso = await _httpClient.GetFromJsonAsync<Curso>($"api/curso{ID}");

            return curso;
        }

        public async Task<Curso> CreateCurso(Curso curso)
        {
            var addCurso = await _httpClient.PutAsJsonAsync<Curso>($"api/curso", curso);
            var content = await addCurso.Content.ReadFromJsonAsync<Curso>();

            return content;
        }

        public async Task<Curso> UpdateCurso(Curso Curso)
        {
            var cursoEditar = await _httpClient.PostAsJsonAsync<Curso>($"api/curso/{Curso.CursoId}", Curso);
            return await cursoEditar.Content.ReadFromJsonAsync<Curso>();
        }

        public async Task DeleteCurso(int ID)
        {
           await _httpClient.DeleteAsync($"api/curso/{ID}");
        }
    }
}
