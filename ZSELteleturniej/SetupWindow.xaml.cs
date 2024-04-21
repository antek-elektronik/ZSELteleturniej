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

namespace ZSELteleturniej
{
    /// <summary>
    /// Logika interakcji dla klasy SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public List<string> Ports = new List<string>();

        public SetupWindow()
        {
            InitializeComponent();
        }

        public void ShowData()
        {
            foreach (string element in Ports)
            {
                comList.Items.Add(element);
            }
        }
    }
}
