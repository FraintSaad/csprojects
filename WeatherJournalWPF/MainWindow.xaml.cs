using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherJournalWPF
{
  
    public partial class MainWindow : Window
    {
        public const string PATH = @"Weather.txt";
        readWindow readWindow = new readWindow();
        writeWindow writeWindow = new writeWindow();
        public MainWindow()
        {
            InitializeComponent();

            RadioButton choiceRead = rdbDataRead;
            RadioButton choiceWrite = rdbDataWrite;
            choiceRead.Checked += RadioButton_Checked;
            choiceWrite.Checked += RadioButton_Checked;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbDataRead.IsChecked == true)
            {
                readWindow.ShowDialog();
            }
            else if (rdbDataWrite.IsChecked == true)
            {
                writeWindow.ShowDialog();
            }
        }

    }
}