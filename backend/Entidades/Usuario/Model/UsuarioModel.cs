using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entidades.Usuario.Model
{
    public class UsuarioModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        // ta com erro essa poha
        //[Required]
        // [Compare("Senha", ErrorMessage = "Senhas divergentes")]
        // public string ConfirmarSenha { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}