using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalCursos.Models.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o email do aluno")]
        [EmailAddressAttribute]
        public string Email { get; set; }       
        public string Senha { get; set; }

    }
}
