using JournalLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherJournalWPF
{
    public class JournalDbContext : DbContext
    {
        public DbSet<JournalEntry> WeatherJournal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\user\Desktop\Weather_Journal.db");
        }
    }
}
