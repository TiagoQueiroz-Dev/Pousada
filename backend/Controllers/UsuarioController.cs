using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Entidades.Usuario.Model;
using backend.Repository.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _IUsuarioRepository;

        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            _IUsuarioRepository = iUsuarioRepository;
        }

        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> Cadastro(UsuarioModel usuario)
        {
            var vali_1 = await _IUsuarioRepository.Cadastro(usuario);

            if (vali_1 == "Ok")
            {
                return Ok();
            }else{
                return BadRequest(vali_1);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string Nome, string Senha)
        {
            var teste = await _IUsuarioRepository.Login(Nome,Senha);

            if(teste)
            {
                return Ok();
            }else{
                return BadRequest(teste);
            }
        }
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _IUsuarioRepository.Logout();
            return Ok();
        }

    }
}