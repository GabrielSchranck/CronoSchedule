using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedule.Model.Entities;

namespace Schedule.Model.Repositories
{
    public interface IScheduleRepository
    {
        Task AddScheduleAsync(ScheduleData schedule);
        Task<ScheduleData> GetScheduleByIdAsync(int id);
        Task<IEnumerable<ScheduleData>> GetAllSchedulesAsync();
        Task UpdateScheduleAsync(ScheduleData schedule);
    }
}
