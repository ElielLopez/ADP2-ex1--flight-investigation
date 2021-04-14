using ADP2.Models;
using ADP2.ViewModel;
using Microsoft.Win32;
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

namespace ADP2.Views
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        private DashBoardViewModel vm;
        private DashBoardModel mod;
        private float aspeed;
        public DashBoard()
        {
            InitializeComponent();
            vm = new DashBoardViewModel(new DashBoardModel());
            mod = new DashBoardModel();
            DataContext = vm;
        }

        private void OpenXMLFile_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                 filename = openFileDialog.FileName;
                xmlFileNAmeTextBox.Text = filename;
            }
            vm.OpenXMLFile(filename);
        }

/*        public void getDashValues()
        {
            this.aspeed = vm.VM_AirSpeed;
            //this.aspeed = mod.AirSpeed;
            AirSpeedVal.Content = aspeed;
            GroundSpeedVal.Content = aspeed;
            Console.WriteLine("THIS IS AIRSPEED {0}", aspeed);
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //getDashValues();
            this.aspeed = vm.VM_AirSpeed;
            
            AirSpeedVal.Content = aspeed;
            GroundSpeedVal.Content = aspeed;
            Console.WriteLine("VIEWMODEL AIRSPEED {0}", aspeed);


            AirSpeedVal.Content = vm.VM_AirSpeed;
            Console.WriteLine("---------------- AIRSPEED {0}", AirSpeedVal.Content);


            this.aspeed = mod.AirSpeed;
            Console.WriteLine("MODEL AIRSPEED {0}", aspeed);


        }
    }
}
//vm.PropertyChanged += (sender, args) => { Vm_PropertyChanged(sender, args)};