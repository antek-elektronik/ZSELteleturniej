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
    /// Logika interakcji dla klasy OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {


        public OperatorWindow()
        {
            SetResources();

            InitializeComponent();
        }

        void SetResources() //hide it all in a nice function so nobody sees this abomination 
        {
            /*
             * what did I do here? Explanation:
             * I need to have 10 elements next to each other that will work even if we resize window. I'm sure there are better ways of doing this, but I'm a simple, stupid human being so I decided to hard-code it so it wouldn't resize whatsoever.
             * yeah, yeah stupid solution, but do it better yourself then!
             * 
             * Here, on c# side I'm creating system resources before any window initialization or anything
             * Then in xaml another one in resources section because why not?: 
             * 
             * <Window.Resources>
                    <System:Double x:Key="CollumnTopMarginVar">64</System:Double>
               </Window.Resources>
             * 
             * so now we have a main CollumnMarginVar that contains every collumns width
             * then every single collumn gets their own system resource 
             * first one will have CollumnMarginVar0, second one CollumnMarginVar1, ... you get it
             * 
             * I wonder how many problems will it generate in future.....
             * 
             * - Antoni G. 03.05.2024
             */

            double collumnWidth = 68; //this will be the base of our ui, every element will have this width

            Resources.Add("CollumnWidthVar", collumnWidth); //so we add this to our system resources to use it later in xaml

            for (int i = 0; i < 11; i++) //to save time writing the code, I made a loop creating all 10 system resources, every single one precisely collumnWidth from each other (every single one will have collumnWidth more margin from the right, not the best option but it should work)
            {
                Resources.Add("CollumnWidthVar" + i.ToString(), collumnWidth * i); // some shady code to make it work
            }
        }
    }
}
