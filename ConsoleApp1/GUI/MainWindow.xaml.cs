using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller c;
        public MainWindow()
        {
            c = new Controller();
            InitializeComponent();
        }

        private void EnterData_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SearchData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
