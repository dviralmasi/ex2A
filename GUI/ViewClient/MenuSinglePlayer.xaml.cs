using GUI.ViewModel;
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

namespace GUI.ViewClient
{
    /// <summary>
    /// Interaction logic for ManuSinglePlayer.xaml
    /// </summary>
    public partial class MenuSinglePlayer : Window
    {
        private SinglePlayerViewModel vm;

        public MenuSinglePlayer()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;
        }

        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            // generate the maze
            vm.exeCommand("generate");
            //here loaded function will be calling
            SinglePlayer single = new SinglePlayer();
            single.Show();
        }

        private void MenuSinglePlayer_Loaded(object sender, RoutedEventArgs e)
        {
            DataUserControl.DataContext = vm;
        }
    }
}