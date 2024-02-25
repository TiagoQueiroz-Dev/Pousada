using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entidades.Usuario.Model;
using Microsoft.AspNetCore.Identity;

namespace backend.Repository.Usuarios
{
    public interface IUsuarioRepository
    {
        public Task<string> Cadastro(UsuarioModel usuario);
        public Task<bool> Login(string Nome,string Senha);
        public Task<bool> Logout();
    }
}