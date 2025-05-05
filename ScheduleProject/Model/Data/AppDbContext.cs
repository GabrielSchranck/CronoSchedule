using Microsoft.EntityFrameworkCore;
using Schedule.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Data
{
    public class AppDbContext : DbContext
    {
        private string dbPath;
        public DbSet<ScheduleData> Schedules { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}
