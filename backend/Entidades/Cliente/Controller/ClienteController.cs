using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entidades.Cliente.Model;
using backend.Entidades.Cliente.Models.Input;
using backend.Entidades.Cliente.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Entidades.Cliente.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("CadastroCliente")]
        public async Task<IActionResult> CadastrarCliente([FromBody] InCadastrarCliente novoCliente)
        {
            try
            {
                await _clienteService.CadastrarCliente(novoCliente);
                return Ok("Cadastro Realizado com Sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Ocorreu um erro no cadastro do usuário: {novoCliente.Nome}");
            }
        }

        [HttpGet]
        [Route("BuscarCadastro")]
        public async Task<IActionResult> BuscarClientePorPalavra([FromQuery] string busca)
        {
            try
            {
                var clientesEncontrados = await _clienteService.BuscarClientes(busca);
                if (clientesEncontrados.Any())
                {
                    return Ok(clientesEncontrados);
                }
                else
                {
                    return NotFound("Não houve resultados para busca");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao realizar a busca");
            }
        }

        [HttpPut]
        [Route("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCadastro([FromQuery] int id, [FromBody] InCadastrarCliente novosDadosCliente)
        {
            try
            {
                var clienteExiste = await _clienteService.ClienteExistenteId(id);

                if (clienteExiste)
                {
                    await _clienteService.AtualizarCadastro(id, novosDadosCliente);
                    return Ok($"Cadastro de {novosDadosCliente.Nome} devidamente atualizado");
                }
                else
                {
                    return NotFound("Cliente não encontrado.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Cadastro do cliente {novosDadosCliente.Nome} não foi atualizado\n{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DesabilitarCliente")]
        public async Task<IActionResult> DesabilitarCliente([FromQuery] int id)
        {
            try
            {
                await _clienteService.DesabilitarCliente(id);
                return Ok("Cliente Desabilitado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPatch]
        [Route("ReabilitarCliente")]
        public async Task<IActionResult> ReabilitarCliente([FromQuery] int id)
        {
            try
            {
                
                await _clienteService.ReabilitarCadastro(id);
                return Ok("Cliente Reabilitado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}