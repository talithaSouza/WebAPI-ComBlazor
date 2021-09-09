using DigitalCursos.Models.Models;
using DigitalCursosAPI.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursosAPI.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _context;
        public CursoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Curso> AddCurso(Curso curso)
        {
            var result = await _context.Cursos.AddAsync(curso);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<Curso> DeleteCurso(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(x => x.CursoId == id);

            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return curso;
            }
            return null;
        }

        public async Task<Curso> GetCurso(int id)
        {
            var curso = _context.Cursos.AsNoTracking().FirstOrDefault(x => x.CursoId == id);

            if (curso != null)
                return curso;

            return null;
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return _context.Cursos.AsNoTracking().ToList();
        }

        public async Task<Curso> UpdateCurso(Curso curso)
        {
            var result = _context.Cursos.FirstOrDefault(x => x.CursoId == curso.CursoId);
            if(result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(curso);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
