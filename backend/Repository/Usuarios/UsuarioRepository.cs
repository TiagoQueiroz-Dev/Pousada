using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Entidades.Usuario.Model;
using Microsoft.AspNetCore.Identity;

namespace backend.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Cadastro(UsuarioModel usuario)
        {
            var user = new IdentityUser(){
                UserName = usuario.Nome,
                Email = usuario.Email,
                PhoneNumber = usuario.Telefone
            };

            var vali_1 =  await _userManager.CreateAsync(user,usuario.Senha);

            var Result = new StringBuilder();

            foreach (var error in vali_1.Errors)
            {
                Result.AppendLine(error.Description);
            }
            
            if (vali_1.Succeeded)
            {
                return "Ok";
            }else{
                return Result.ToString();
            }
        }

        public async Task<bool> Login(string Nome, string Senha)
        {
            
            var result = await _signInManager.PasswordSignInAsync(Nome,Senha,false,false);
        
            if(result.Succeeded)
            {
                return true;
            }else{

                Console.WriteLine(result.ToString());
                return false;
            }
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
                
            return true;
        }
    }
}