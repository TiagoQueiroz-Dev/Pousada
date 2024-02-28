using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entidades.Cliente.Model;
using backend.Entidades.Cliente.Models.Input;
using backend.Entidades.Cliente.Repository;
using backend.Migrations;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.Entidades.Cliente.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CadastrarCliente(InCadastrarCliente dados)
        {
            ClienteModel novoCliente = new ClienteModel()
            {
                Nome = dados.Nome,
                Email = dados.Email,
                Tel = dados.Tel,
                CPF = dados.CPF
            };
            await _clienteRepository.CadastrarCliente(novoCliente);
        }

        public async Task AtualizarCadastro(int id,InCadastrarCliente dados)
        {
            try
            {
                ClienteModel clienteAtualizado = new ClienteModel()
                {
                    Id = id,
                    Nome = dados.Nome,
                    Email = dados.Email,
                    Tel = dados.Tel,
                    CPF = dados.CPF
                };

                await _clienteRepository.AtualizarCliente(clienteAtualizado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ClienteModel>> BuscarClientes(string busca)
        {
            var resultadoBusca = await _clienteRepository.BuscarClientes(busca);
            return resultadoBusca.ToList();
        }

        public async Task<bool> ClienteExistenteId(int id)
        {
            var resultadoBusca = await BuscarClientes(id.ToString());


            if (resultadoBusca.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DesabilitarCliente(int id)
        {
            try
            {
                await _clienteRepository.DesabilitarCliente(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task ReabilitarCadastro(int id){
            try{
                await _clienteRepository.ReabilitarCliente(id);
            }
            catch(Exception ex){
                throw ex;
            }
        }
    }
}