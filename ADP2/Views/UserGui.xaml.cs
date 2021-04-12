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
    /// Interaction logic for mediaPlayer.xaml
    /// </summary>
    public partial class UserGui : UserControl
    {
/*        Boolean isPlayPressed = true;
        Boolean isPausePressed = false;*/
        UserGUIViewModel vm;

        public string filename;

        public UserGui()
        {
            InitializeComponent();
            vm = new UserGUIViewModel(new UserGUIModel());
            DataContext = vm;
        }

        // FileLoader
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            Nullable<bool> result = openFileDialog.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                filename = openFileDialog.FileName;
                fileNameTextBox.Text = filename;
            }
            vm.OpenCSVFile(filename);
        }


        // MediaPlayer View
        private void isPlay(object sender, RoutedEventArgs e)
        {
            //this.vm.VM_Play = true;
            /*          isPlayPressed = true;
                      isPausePressed = false;*/
            vm.playVideo();
        }

        private void isPause(object sender, RoutedEventArgs e)
        {
            //this.vm.StopPlay(isPausePressed);
            //vm.VM_Pause = true;
/*            isPausePressed = true;
            isPlayPressed = false;*/
            vm.pauseVideo();
        }
    }
}
