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
using static System.Net.Mime.MediaTypeNames;

namespace WeatherJournalWPF
{
    /// <summary>
    /// Interaction logic for readWindow.xaml
    /// </summary>
    public partial class readWindow : Window
    {
        string pathFromMainWindow = MainWindow.PATH;
        public readWindow()
        {
            InitializeComponent();
           
        }

        private void btnDateConfirm_Click(object sender, RoutedEventArgs e)
        {
            string dateForRead = txtDateForCheck.Text;

            try
            {
                string[] lines = File.ReadAllLines(pathFromMainWindow);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');

                    
                    if (data.Length >= 4 && data[0].Trim() == dateForRead.Trim())
                    {
                       
                        string message = $"Дата: {data[0].Trim()}\nТемпература: {data[1].Trim()}\nВлажность: {data[2].Trim()}\nОписание: {data[3].Trim()}";
                        MessageBox.Show(message);
                        return; 
                    }
                }

                MessageBox.Show("Данные для введенной даты не найдены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        }
    }
