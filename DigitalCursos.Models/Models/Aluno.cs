using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalCursos.Models.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "Informe o nome do Aluno")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o email do aluno")]
        [EmailAddressAttribute]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento do aluno")]
        public DateTime Nascimento { get; set; }
        public byte[] Foto { get; set; }
        public Genero Genero { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
