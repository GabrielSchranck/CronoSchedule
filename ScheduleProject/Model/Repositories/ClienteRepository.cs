using Schedule.Model.Data;
using Schedule.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _DbContext;

        public ClienteRepository(DatabaseContext dbContext)
        {
            this._DbContext = dbContext;
        }

        public async Task CreateAsync(Cliente cliente)
        {
            await _DbContext._connection.InsertAsync(cliente);
        }

        public Task DeleteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _DbContext._connection.Table<Cliente>().ToListAsync();
        }

        public Task UpdateAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
