using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entidades.Cliente.Model
{
    public class ClienteModel
    {
        public ClienteModel()
        {
            IsDeleted = false;
        }

        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public int CPF { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsDeleted {get ;set; }
    }
}