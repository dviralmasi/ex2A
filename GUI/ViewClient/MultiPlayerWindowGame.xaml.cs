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
    /// Interaction logic for MultiPlayerWindowGame.xaml
    /// </summary>
    public partial class MultiPlayerWindowGame : Window
    {
        private MultiPlayerViewModel vm;

        public MultiPlayerWindowGame(MultiPlayerViewModel newVm)
        {
            InitializeComponent();
            this.vm = newVm;
            this.DataContext = vm;
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadedPlayer2(object sender, RoutedEventArgs e)
        {
            MazePlayer mazePlayer = new MazePlayer();
        }

        private void LoadedPlayer1(object sender, RoutedEventArgs e)
        {
            MazePlayer mazePlayer = new MazePlayer();
        }
    }
}
