using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalCursosWeb.Service
{
    public interface IAlunoService
    {
        public Task<IEnumerable<Aluno>> GetAlunos();
        public Task<Aluno> GetAluno(int id);
        public Task<Aluno> CreateAluno(Aluno aluno);
        public Task<Aluno> UpdateAluno(Aluno aluno);
        public Task DeleteAluno(int IdAluno);
    }
}
