using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entidades.Cliente.Model;

namespace backend.Entidades.Cliente.Repository
{
    public interface IClienteRepository
    {
        public Task<ClienteModel>CadastrarCliente(ClienteModel novoCliente);
        public Task<IEnumerable<ClienteModel>>BuscarClientes(string busca);
        public Task<ClienteModel>AtualizarCliente(ClienteModel novosDados);
        public Task<ClienteModel>ReabilitarCliente(int idCliente); 
        public Task<ClienteModel>DesabilitarCliente(int idCliente);


    }
}