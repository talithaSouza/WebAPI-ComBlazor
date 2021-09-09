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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _repository;
        public CursoController(ICursoRepository cursoRepository)
        {
            _repository = cursoRepository;
        }

        public async Task<ActionResult<Curso>> GetCurso()
        {
            try
            {
                var result = await _repository.GetCursos();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Retornar cursos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Curso>> GetCurso(int id, string nome)
        {
            try
            {
                var result = await _repository.GetCurso(id);
                if (result == null)
                    return NotFound($"Curso {nome} com o id {id} não encontrado");

                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Retornar cursos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> CreateCurso(Curso curso)
        {
            try
            {
                if(curso != null)
                {
                    var result = await _repository.AddCurso(curso);

                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Cadastrar cursos");
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Curso>> UpdateCurso(int id, Curso curso)
        {
            try
            {
                if (id != curso.CursoId)
                    return BadRequest($"Aluno com id = {id} nõa confere com o aluno a ser atualizado");

                var result = await _repository.GetCurso(id);
                if (result == null)
                    return NotFound($"Curso com id {id} não foi encontrado");

                return Ok(await _repository.UpdateCurso(curso));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Editar cursos");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Curso>> DeleteCurso(int id)
        {
            try
            {
                var cursoDeletar = await _repository.GetCurso(id);
                if (cursoDeletar == null)
                    return NotFound($"Curso com id {id} não encontrado");

                return await _repository.DeleteCurso(id);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Deletar cursos");
            }
        }

    }
}
