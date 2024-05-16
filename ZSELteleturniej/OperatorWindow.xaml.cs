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
            InitializeComponent();

            //SetResources();

            
        }

        void SetResources() //hide it all in a nice function so nobody sees this abomination 
        {
            /*
             * what did I do here? Explanation:
             * I need to have 10 elements next to each other that will work even if we resize window. I'm sure there are better ways of doing this, but I'm a simple, stupid human being so I decided to hard-code it so it wouldn't resize whatsoever.
             * yeah, yeah stupid solution, but do it better yourself then!
             * 
             * Here, on c# side I'm creating system resources before any window initialization or anything
             * Then in xaml another one in resources section because VS designer cannot see that C# will assign the values and keeps f***ing up so I gave hin some dummy values to still be able to use designer and real values are assigned here, in c# code 
             
             <System:Double x:Key="CollumnTopMarginVar">70</System:Double>
             <System:Double x:Key="CollumnBottomMarginVar">70</System:Double>
             <System:Double x:Key="CollumnWidthVar0">0</System:Double>
             <System:Double x:Key="CollumnWidthVar1">100</System:Double>
             <System:Double x:Key="CollumnWidthVar2">200</System:Double>
             <System:Double x:Key="CollumnWidthVar3">300</System:Double>
             <System:Double x:Key="CollumnWidthVar4">400</System:Double>
             <System:Double x:Key="CollumnWidthVar5">500</System:Double>
             <System:Double x:Key="CollumnWidthVar6">600</System:Double>
             <System:Double x:Key="CollumnWidthVar7">700</System:Double>
             <System:Double x:Key="CollumnWidthVar8">800</System:Double>
             <System:Double x:Key="CollumnWidthVar9">900</System:Double>
             <System:Double x:Key="CollumnWidthVar">100</System:Double>
            
             *(this piece of code was created by subscript "xaml automation1.py")
             *
             *
             * so now we have a main CollumnMarginVar that contains every collumns width
             * then every single collumn gets their own system resource 
             * first one will have CollumnMarginVar0, second one CollumnMarginVar1, ... you get it
             * 
             * I wonder how many problems will it generate in future.....
             * 
             * - Antoni G. 03.05.2024
             * 
             * 
             */

            Resources.Clear(); //clear theese dummy resources from the xaml

            double collumnWidth = 50; //this will be the base of our ui, every element will have this width
            double collumnTop = 70;
            double collumnBottom = 70;


            //so we add this to our system resources to use it later in xaml
            Resources.Add("CollumnTopMarginVar", collumnTop); 
            Resources.Add("CollumnWidthVar", collumnWidth); 
            Resources.Add("CollumnBottomMarginVar", collumnBottom);

            for (int i = 0; i < 10; i++) //to save time writing the code, I made a loop creating all 10 system resources, every single one precisely collumnWidth from each other (every single one will have collumnWidth more margin from the right, not the best option but it should work)
            {
                Resources.Add("CollumnWidthVar" + i.ToString(), collumnWidth * i); // some shady code to make it work
            }

            
        }

        
    }
}
