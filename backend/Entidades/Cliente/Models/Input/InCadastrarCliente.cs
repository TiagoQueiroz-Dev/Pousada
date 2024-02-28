using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entidades.Cliente.Models.Input
{
    public class InCadastrarCliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; } 
        public string CPF { get; set; }           
        public string Tel { get; set; }
    }
}