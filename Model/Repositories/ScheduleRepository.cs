using Schedule.Model.Data;
using Schedule.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DatabaseContext _DbContext;

        public ScheduleRepository(DatabaseContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task AddScheduleAsync(ScheduleData schedule)
        {
            await _DbContext._connection.InsertAsync(schedule);
        }

        public Task DeleteScheduleAsync(ScheduleData schedule)
        {
            throw new NotImplementedException();
        }

        public Task DoneScheduleAsync(ScheduleData schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ScheduleData>> GetAllSchedulesAsync()
        {
            var schedules =  await _DbContext._connection.Table<ScheduleData>().ToListAsync();

            foreach(var schedule in schedules)
            {
                schedule.Cliente = await _DbContext._connection.Table<Cliente>().FirstOrDefaultAsync(c => c.Id == schedule.CodigoCliente);
            }

            return schedules;
        }

        public Task<ScheduleData> GetScheduleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateScheduleAsync(ScheduleData schedule)
        {
            await _DbContext._connection.UpdateAsync(schedule);
        }
    }
}
