using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsuarioController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> Cadastro(UsuarioCadastroModel usuario)
        {
            var user = new IdentityUser(){
                UserName = usuario.Nome,
                Email = usuario.Email
            };

            var vali_1 = await _userManager.CreateAsync(user,usuario.Senha);

            if (vali_1.Succeeded)
            {
                return Ok();
            }else{
                return BadRequest(vali_1.Errors);
            }
        }

    }
}