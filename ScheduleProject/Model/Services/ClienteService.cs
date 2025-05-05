using Schedule.Model.Entities;
using Schedule.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task CreateAsync(Cliente cliente)
        {
            await _clienteRepository.CreateAsync(cliente);
        }

        public Task DeleteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public Task UpdateAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
