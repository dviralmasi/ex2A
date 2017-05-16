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
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerViewModel vm;

        public SinglePlayer()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel();
            this.DataContext = vm;
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            AreYouSureWindow sureWindow = new AreYouSureWindow();
            bool? result = sureWindow.ShowDialog();
            if (result == true)
            {
                // restart the game
            }
            else
            {
                // continue the game

            }
        }

        private void SinglePlayer_Loaded(object sender, RoutedEventArgs e)
        {
            MazePlayer mazePlayer = new MazePlayer();
        }
    }
}
