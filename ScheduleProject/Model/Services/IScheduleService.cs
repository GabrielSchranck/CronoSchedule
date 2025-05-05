using Schedule.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Services
{
    public interface IScheduleService
    {
        Task CreateAsync(ScheduleData schedule);
        Task<IEnumerable<ScheduleData>> GetAllAsync();
        Task<ScheduleData> GetByIdAsync(int id);
        Task UpdateAsync(ScheduleData schedule);
        Task DeleteAsync(ScheduleData schedule);
    }
}
