using DigitalCursos.Models.Models;
using DigitalCursosAPI.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursosAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            var result = await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Usuario> DeleteUsuario(int id)
        {
            var usuarioDeletar = _context.Usuarios.FirstOrDefault(x => x.Id == id);
            if(usuarioDeletar != null)
            {
                _context.Usuarios.Remove(usuarioDeletar);
                await _context.SaveChangesAsync();
                return usuarioDeletar;
            }
            return null;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return _context.Usuarios.AsNoTracking().ToList();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            var usuarioEditar = await GetUsuario(usuario.Id);
            if (usuarioEditar != null)
            {
                _context.Entry(usuarioEditar).CurrentValues.SetValues(usuario);
                await _context.SaveChangesAsync();
                return usuarioEditar;
            }
            return null;
        }

        public async Task<Usuario> RetornarPorUsuarioESenha(string email, string senha)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Email == email && x.Senha == senha);

        }
    }
}
