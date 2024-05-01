using JournalLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using SQLitePCL;
using System.Diagnostics;


namespace WeatherJournalWPF
{


    public partial class MainWindow : Window
    {
        private JournalDbContext _dbContext = new JournalDbContext();
        public ObservableCollection<JournalEntry> JournalEntries { get; } = new ObservableCollection<JournalEntry>();

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            
            foreach (var entry in _dbContext.WeatherJournal)
            {
                JournalEntries.Add(entry);
            }
        }

        private void btnAddEntry_Click(object sender, RoutedEventArgs e)
        {
            
            int temperature = Convert.ToInt32(txtTemperature.Text);
            int humidity = Convert.ToInt32(txtHumidity.Text);
            var date = Convert.ToDateTime(txtData.Text);
            string description = cmbDescription.SelectedItem?.ToString();

            
            JournalEntry newEntry = new JournalEntry
            {
                Date = date,
                Temperature = temperature,
                Humidity = humidity,
                Description = description
            };

              
                _dbContext.WeatherJournal.Add(newEntry);
                _dbContext.SaveChanges();

                JournalEntries.Add(newEntry);
            
        }
    }


}
