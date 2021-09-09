using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalCursosAPI.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<Aluno> AddAluno(Aluno aluno);
        Task<Aluno> UpdateAluno(Aluno aluno);
        Task<Aluno> DeleteAluno(int id);
    }
}
