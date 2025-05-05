using Schedule.Model.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Data
{
    public class DatabaseContext
    {
        private const string DB_NAME = "meubanco.db";
        public readonly SQLiteAsyncConnection _connection;

        public DatabaseContext()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<ScheduleData>();
            _connection.CreateTableAsync<Cliente>();
        }
    }
}
