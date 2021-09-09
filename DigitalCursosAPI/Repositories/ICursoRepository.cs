using DigitalCursos.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursosAPI.Repositories
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> GetCurso(int id);
        Task<Curso> AddCurso(Curso curso);
        Task<Curso> UpdateCurso(Curso curso);
        Task<Curso> DeleteCurso(int id);
    }
}
