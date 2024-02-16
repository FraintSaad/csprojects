
using JournalLibrary;
using JournalLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;



namespace WeatherJournalWPF
{
  
    public partial class MainWindow : Window
    {
        public ObservableCollection<JournalEntry> JournalEntries { get; } = new ObservableCollection<JournalEntry>();
        public MainWindow()
        {
            InitializeComponent();
            JournalStorage storage = new JournalStorage();
            foreach(var entry in storage.GetAllJournalEntrys())
            {
                JournalEntries.Add(entry);
            }
            
        }

        private void btnAddEntry_Click(object sender, RoutedEventArgs e)
        {
            decimal temperature = Convert.ToDecimal(txtTemperature.Text);
            decimal humidity = Convert.ToDecimal(txtHumidity.Text);
            DateTime date = Convert.ToDateTime(txtData.Text);
            ComboBoxItem selectedItem = (ComboBoxItem)cmbDescription.SelectedItem;
            string description = (string)selectedItem.Content;
            JournalEntry newEntry = new JournalEntry();
            newEntry.Temperature = temperature;
            newEntry.Humidity = humidity;
            newEntry.Date = date;
            newEntry.Description = description;
            JournalEntries.Add(newEntry);
            
        }
    }
}