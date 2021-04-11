using ADP2.Models;
using ADP2.ViewModel;
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
    public partial class mediaPlayer : UserControl
    {
        MediaPlayerViewModel vm;
/*        volatile Boolean isPlayPressed = true;
        volatile Boolean isPausePressed = false;*/
        public mediaPlayer()
        {
            InitializeComponent();
            vm = new MediaPlayerViewModel(new MediaPlayerModel());
            DataContext = vm;
        }

        private void isPlay(object sender, RoutedEventArgs e)
        {
/*            isPlayPressed = true;
            isPausePressed = false;*/
            this.vm.VM_Play = true;
        }

        private void isPause(object sender, RoutedEventArgs e)
        {
/*            isPlayPressed = false;
            isPausePressed = true;*/
            //this.vm.StopPlay(isPausePressed);
            vm.VM_Pause = true;
        }
    }
}
