using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Database;
using backend.Entidades.Cliente.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace backend.Entidades.Cliente.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PousadaContext _pousadaContext;

        public ClienteRepository(PousadaContext pousadaContext)
        {
            _pousadaContext = pousadaContext;
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel novosDados)
        {
            try
            {
                var cadastro = await _pousadaContext.Clientes.FindAsync(novosDados.Id);

                if (cadastro != null && cadastro.Deletado != true)
                {
                    foreach (var item in typeof(ClienteModel).GetProperties())
                    {
                        if (item.Name != nameof(ClienteModel.Id))
                        {
                            item.SetValue(cadastro, item.GetValue(novosDados));
                        }
                    }

                    await _pousadaContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Não é possivel alterar dados de um cliente desabilitado");
                }

                return novosDados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro no update: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ClienteModel>> BuscarClientes(string busca)
        {
            return await _pousadaContext.Clientes
                .Where(c =>
                    c.Id.ToString() == busca ||
                    c.Nome.Contains(busca) ||
                    c.CPF.Contains(busca) ||
                    c.Tel.Contains(busca) ||
                    c.Email.Contains(busca)).ToListAsync();
        }

        public async Task<ClienteModel> CadastrarCliente(ClienteModel novoCliente)
        {
            await _pousadaContext.Clientes.AddAsync(novoCliente);
            await _pousadaContext.SaveChangesAsync();
            return novoCliente;

        }

        public async Task<ClienteModel> DesabilitarCliente(int idCliente)
        {
            try
            {
                var cliente = await _pousadaContext.Clientes.FindAsync(idCliente);

                if (cliente != null && cliente.Deletado == false)
                {
                    cliente.Deletado = true;
                    await _pousadaContext.SaveChangesAsync();

                }
                else if (cliente.Deletado == true)
                {
                    throw new Exception($"Cliente já cancelado");
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desabilitar cliente: {ex.Message}");
            }
        }
        public async Task<ClienteModel> ReabilitarCliente(int id)
        {
            try
            {
                var cliente = await _pousadaContext.Clientes.FindAsync(id);
                
                if (cliente != null && cliente.Deletado == true)
                {
                    cliente.Deletado = false;
                    await _pousadaContext.SaveChangesAsync();

                }
                else if (cliente.Deletado == false)
                {
                    throw new Exception($"Cliente ativo");
                }
                return cliente;


            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desabilitar cliente: {ex.Message}");
            }
        }

    }
}