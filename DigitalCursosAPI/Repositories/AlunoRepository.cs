using DigitalCursos.Models.Models;
using DigitalCursosAPI.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursosAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;
        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            var result = await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Aluno> DeleteAluno(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.AlunoId == id);

            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return aluno;
            }

            return null;
        }

        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.AlunoId == id);

            if (aluno != null)
                return aluno;
            

            return null;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            var alunos = _context.Alunos.AsNoTracking().ToList();

            if (alunos != null)
                return alunos;

            return null;
        }

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            var result = _context.Alunos.FirstOrDefault(x => x.AlunoId == aluno.AlunoId);
            if(result != null)
            {
                //result.Nome = aluno.Nome;
                //result.Sobrenome = aluno.Sobrenome;
                //result.Email = aluno.Email;
                _context.Entry(result).CurrentValues.SetValues(aluno);
                //_context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
