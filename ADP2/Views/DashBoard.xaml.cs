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
        public DashBoard()
        {
            InitializeComponent();
            vm = new DashBoardViewModel(new DashBoardModel());
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
        public void setValueAirSpeed()
        {
            AirSpeedVal.Content =  vm.setAirSpeed().ToString();
        }
    }
}
//vm.PropertyChanged += (sender, args) => { Vm_PropertyChanged(sender, args)};