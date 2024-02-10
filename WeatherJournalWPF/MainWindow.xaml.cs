
using JournalLibrary;
using JournalLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;



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

    }
}