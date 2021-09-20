using DigitalCursos.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalCursosWeb.Service
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetCursos();
        public Task<Curso> GetCurso(int ID);
        public Task<Curso> CreateCurso(Curso Curso);
        public Task<Curso> UpdateCurso(Curso Curso);
        public Task DeleteCurso(int ID);
    }
}
