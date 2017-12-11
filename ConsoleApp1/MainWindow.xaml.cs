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

namespace ConsoleApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Controller c = new Controller();

        private void enterSampleCombo_Selected(object sender, RoutedEventArgs e) //should we copy the format to a new window where the combo has the sample type options
        {                                                                        // or should we try to databind two lists to the combobox...
                                                                                 // one would contain the sample types and events upon selection but if the
                                                                                 //second option is selected it goes to a new window with the search by ID...
        }

        private void getSampleCombo_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
