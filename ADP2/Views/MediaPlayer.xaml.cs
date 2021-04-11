﻿using ADP2.Models;
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
        public mediaPlayer()
        {
            InitializeComponent();
            vm = new MediaPlayerViewModel(new MediaPlayerModel());
            DataContext = vm;
        }

        private void isPlay(object sender, RoutedEventArgs e)
        {
            this.vm.StartPlay();
        }

        private void isPause(object sender, RoutedEventArgs e)
        {
            this.vm.StopPlay();
        }
    }
}