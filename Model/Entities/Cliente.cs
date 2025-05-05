using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Model.Entities
{
    [Table("Clientes")]
    public class Cliente
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("nome")]
        public string? Nome { get; set; } = string.Empty;
    }
}
