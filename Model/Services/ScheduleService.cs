using Schedule.Model.Entities;
using Schedule.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            this._scheduleRepository = scheduleRepository;
        }

        public async Task CreateAsync(ScheduleData schedule)
        {
            schedule.CodigoCliente = schedule.Cliente.Id;

            await _scheduleRepository.AddScheduleAsync(schedule);
        }

        public Task DeleteAsync(ScheduleData schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ScheduleData>> GetAllAsync()
        {
            return await _scheduleRepository.GetAllSchedulesAsync();
        }

        public Task<ScheduleData> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ScheduleData schedule)
        {
            await _scheduleRepository.UpdateScheduleAsync(schedule);
        }
    }
}
