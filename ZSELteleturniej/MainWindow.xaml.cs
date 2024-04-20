/*
 * Program do obsługi systemu ZSEL teleturniej
 * System składa się z centrali pracującej na Arduino Mega, komputera z dwoma monitorami oraz 10 stołów dla odpowiadających.
 * 
 * Arduino komunikuje się z oprogramowaniem na komputerze przy wykorzystaniu portu szeregowego
 * 
 * Autorzy projektu
 *  oprogramowanie windows: Antoni Gzara
 *  oprogramowanie Arduino: Bartosz Kuś
 *  hardware: Bartosz Kuś, Antoni Gzara
 *  
 * Założenia:
 *  - program składa się z jednej głównej klasy MainWindow
 *  - klasa ta będzie uruchamiać klasy podrzędne, jedna jako panel sterowania dla obsługującego, drugi jako tabela wyników i informacje dla prowadzącego teleturniej. Osoba osbługująca ma za zadanie przełączać pytania oraz kontrolować poprawność odpoiwiedzi. 
 *
 * 
 */

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
using System.IO.Ports;

namespace ZSELteleturniej
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

        SetupWindow setupWindow = new SetupWindow();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            setupWindow = new SetupWindow(); //reset the setupWindow class

            string[] ports = SerialPort.GetPortNames(); //get all the available com ports

            setupWindow.Ports = ports.ToList<string>(); //pass them to the setup window

            setupWindow.Show();

            setupWindow.ShowData();

        }
    }
}
