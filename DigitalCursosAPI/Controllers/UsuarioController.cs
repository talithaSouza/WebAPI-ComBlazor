using DigitalCursos.Models.Models;
using DigitalCursosAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsuarios()
        {
            try
            {
                var result = await _usuarioRepository.GetUsuarios();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar usuarios");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int Id)
        {
            try
            {
                var result = await _usuarioRepository.GetUsuario(Id);
                if (result == null)
                    return NotFound($"Usuario com id {Id} não foi encontrado");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar usuario");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest();

                var createdUsuario = await _usuarioRepository.AddUsuario(usuario);
                return Ok(createdUsuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao cadastrar usuario");
            }
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int Id, Usuario usuario)
        {
            if(Id != usuario.Id)
                return BadRequest($"Usuario com id = {Id} não confere com o usuario a ser atualizado");

            var usuarioUpdate = await _usuarioRepository.GetUsuario(Id);
            if(usuarioUpdate == null)
                return NotFound($"Usuario com id {Id} não foi encontrado");

            return await _usuarioRepository.UpdateUsuario(usuario);
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<Usuario>> DeleteAluno(int Id)
        {
            try
            {
                var deleteUsuario = _usuarioRepository.GetUsuario(Id);
                if (deleteUsuario == null)
                    return NotFound($"Usuario com id {Id} não foi encontrado");

                return await _usuarioRepository.DeleteUsuario(Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar alunos");
            }
        }
    }
}
