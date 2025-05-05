using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Entities
{
    [Table("Schedules")]
    public class ScheduleData
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("dataAtendimento")]
        public DateTime DataAtendimento { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [Column("codigoCliente")]
        public int CodigoCliente { get; set; }

        // Status 0 = Pendente, 1 = Concluído, 2 = Cancelado
        [Column("status")]
        public int Status { get; set; } = 0;

        [Column("horaAtendimento")]
        public TimeSpan HoraAtendimento { get; set; }

        [Ignore]
        public Cliente Cliente { get; set; } = null!;
    }
}
