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
using System.Windows.Shapes;
using System.IO.Ports;
using System.IO;
using System.Management;

namespace ZSELteleturniej
{
    /// <summary>
    /// Logika interakcji dla klasy SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public string SelectedPort = null; //selected com port for example "COM1" "COM2"
        public bool WindowReady = false; //confirms that port was selected and app is ready for the next step

        public SetupWindow()
        {
            InitializeComponent();
        }

        public void ShowData()
        {
            string[] ports = SerialPort.GetPortNames(); //get all the available com ports
            foreach (string element in ports)
            {
                comList.Items.Add(element);
            }

            string arduinoPort = AutodetectArduinoPort();

            if (arduinoPort != null) {
                ArduinoFoundLabel.Content = "znaleziono Arduino na porcie: " + arduinoPort;
            } 
            else if(arduinoPort == "error")
            {
                ArduinoFoundLabel.Content = "napotkano problem";
            }
            else
            {
                ArduinoFoundLabel.Content = "nie znaleziono Arduino";
            }

            Cursor = Cursors.Arrow;
        }

        private string AutodetectArduinoPort()  //detect Arduino port from stackoverflow
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
                MessageBox.Show(e.Message,"zgłoszono wyjątek!", MessageBoxButton.OK, MessageBoxImage.Error); //report error to the user
                return "error";
            }

            return null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            Cursor = Cursors.Wait; //change cursor for user to know that the app is working
            ShowData();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //refresh button
        {
            Cursor = Cursors.Wait;  //change cursor for user to know that the app is working
            ShowData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //  continue button 
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz kontynuować? Źle wybrany port uniemożliwi poprawne działanie programu!", "ostrzeżenie!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    SelectedPort = comList.SelectedItem.ToString();
                }
                catch
                {
                    MessageBox.Show("aplikacja napotkała błąd! Prawdopodobnie nie wybrano portu COM", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            WindowReady = true;
            Close();
        }
    }
}
