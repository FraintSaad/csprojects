
using JournalLibrary;
using JournalLibrary.Models;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.IO;



namespace WeatherJournalWPF
{

    public partial class MainWindow : Window
    {
        private JournalStorage _journalStorage = new JournalStorage();
        public ObservableCollection<JournalEntry> JournalEntries { get; } = new ObservableCollection<JournalEntry>();
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            JournalStorage storage = new JournalStorage();
            foreach (var entry in storage.GetAllJournalEntrys())
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

            JournalEntry newEntry = new JournalEntry
            {
                Temperature = temperature,
                Humidity = humidity,
                Date = date,
                Description = description
            };
            _journalStorage.AddJournalEntry(newEntry);
            _journalStorage.SaveJournalEntries();
            JournalEntries.Add(newEntry);

        }


    }
}