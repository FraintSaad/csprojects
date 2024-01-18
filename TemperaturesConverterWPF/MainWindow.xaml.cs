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

namespace TemperaturesConverterWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConverter_Click(object sender, RoutedEventArgs e)
        {
            5decimal chislo = Convert.ToDecimal(txtTemperatureSet.Text);
            string choice = Convert.ToString(txtChoice.Text);
            if(choice == "C")
            {
                decimal F=(chislo * 9 / 5) + 32;
                MessageBox.Show("Градусы в Фаренгейтах: " + F);
            }
            else if(choice == "F") 
            {
                decimal C = (chislo - 32) * 5 / 9;
                MessageBox.Show("Градусы в Цельсиях: " + C);
            }
            else
            {
                MessageBox.Show("нужно выбрать C или F");
                return;
            }

        }
    }
}