
using System.ComponentModel.DataAnnotations.Schema;

namespace JournalLibrary.Models
{
    public class JournalEntry
    {

        public int Id { get; set; }
        [Column("Дата")]
        public DateTime Date { get; set; }
        [Column("Температура")]
        public int Temperature { get; set; }
        [Column("Влажность")]
        public int Humidity { get; set; }
        [Column("Описание")]
        public string? Description { get; set; }
    }
}
