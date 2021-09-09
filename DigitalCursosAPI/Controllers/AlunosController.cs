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
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<ActionResult> GetAlunos()
        {
            try
            {
                var result = await _alunoRepository.GetAlunos();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar alunos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Aluno>> GetAluno(int Id)
        {
            try
            {
                var result = await _alunoRepository.GetAluno(Id);
                if (result == null)
                    return NotFound($"Aluno com id {Id} não foi encontrado");

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar alunos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> CreateAluno(Aluno aluno)
        {
            try
            {
                if (aluno == null)
                    return BadRequest();

                var createdAluno = await _alunoRepository.AddAluno(aluno);
                return CreatedAtAction(nameof(GetAluno),
                    new { id = createdAluno.CursoId }, createdAluno);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar alunos");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Aluno>> UpdateAluno(int id, Aluno aluno)
        {
            try
            {
                if (id != aluno.AlunoId)
                    return BadRequest($"Aluno com id = {id} nõa confere com o aluno a ser atualizado");

                var alunoToUpdate = await _alunoRepository.GetAluno(id);
                if (alunoToUpdate == null)
                    return NotFound($"Aluno com id {id} não foi encontrado");

                return await _alunoRepository.UpdateAluno(aluno);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar alunos");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            try
            {
                var alunoToDelete = await _alunoRepository.GetAluno(id);
                if(alunoToDelete == null)
                    return NotFound($"Aluno com id {id} não foi encontrado");

                return await _alunoRepository.DeleteAluno(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " Erro ao retornar alunos");
            }
        }
    }
}
        
        
    

