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
        public string SelectedPort = null;

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
        }

        private string AutodetectArduinoPort()
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
                MessageBox.Show(e.Message,"zgłoszono wyjątek!", MessageBoxButton.OK, MessageBoxImage.Error);
                return "error";
            }

            return null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowData();
        }
    }
}
