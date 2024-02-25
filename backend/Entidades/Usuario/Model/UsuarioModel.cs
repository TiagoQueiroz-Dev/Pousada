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
        [Required]
        public string Telefone { get; set; }
        public string? Endereço { get; set; }
        public string? Hitorico_Acesso { get; set; }
        [Required]
        [Compare("Senha", ErrorMessage = "Senhas Divergentes")]
        public string ConfirmarSenha { get; set; }
    }
}