using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherJournalWPF
{
    /// <summary>
    /// Interaction logic for writeWindow.xaml
    /// </summary>
    public partial class writeWindow : Window
    {
        string pathFromMainWindow = MainWindow.PATH;
        public writeWindow()
        {
            InitializeComponent();
        }

        private void btnAddInformation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string newLine = $"{txtDateForSave.Text},{txtTemperatureForSave.Text},{txtHumidityForSave.Text},{txtOverviewForSave.Text}\r\n";
                File.AppendAllText(pathFromMainWindow, newLine);
                MessageBox.Show("Строка успешно добавлена в файл");
            }
            catch (UnauthorizedAccessException)
            {
               MessageBox.Show("Нет доступа к указанному пути");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла непонятная ошибка");
                return;
            }
         
        }
    }
     
}
