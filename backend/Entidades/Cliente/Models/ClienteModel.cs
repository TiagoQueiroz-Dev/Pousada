using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entidades.Cliente.Model
{
    public class ClienteModel
    {
        public ClienteModel()
        {
            
        }

        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Column("Deletado")]
        public bool Deletado { get; set; } = false;

    }
}