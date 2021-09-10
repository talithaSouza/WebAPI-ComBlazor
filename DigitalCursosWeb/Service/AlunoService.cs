using DigitalCursos.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DigitalCursosWeb.Service
{
    public class AlunoService : IAlunoService
    {
        public HttpClient _httpClient;

        public AlunoService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            var alunos = await _httpClient.GetFromJsonAsync<IEnumerable<Aluno>>("api/alunos");

            return alunos;
        }
        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _httpClient.GetFromJsonAsync<Aluno>($"api/aluno/{id}");

            return aluno;
        }

        public async Task<Aluno> CreateAluno(Aluno novoAluno)
        {
            var response = await _httpClient.PutAsJsonAsync<Aluno>($"api/aluno", novoAluno);
            var content = await response.Content.ReadFromJsonAsync<Aluno>();

            return content;
        }

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            var response = await _httpClient.PutAsJsonAsync<Aluno>($"api/alunos/{aluno.AlunoId}", aluno);
            var content = await response.Content.ReadFromJsonAsync<Aluno>();

            return content;
        }
        public async Task DeleteAluno(int IdAluno)
        {
            await _httpClient.DeleteAsync($"api/alunos/{IdAluno}");
        }
    }
}
