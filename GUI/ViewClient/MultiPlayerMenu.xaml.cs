using GUI.ViewModel;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MultiPlayerMenu.xaml
    /// </summary>
    public partial class MultiPlayerMenu : Window
    {
         private ObservableCollection <string> listGameToJoin = new ObservableCollection<string>();
        private MultiPlayerViewModel vm;
        public MultiPlayerMenu()
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel();
            this.DataContext = vm;
        }
      

        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult wait = MessageBox.Show("Please wait for other player");
            vm.StartGame();
            MultiPlayerWindowGame multiPlayerGame = new MultiPlayerWindowGame(vm);
            multiPlayerGame.Show();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            string gameName = (string)comboBox.SelectedItem;
            vm.JoinGame(gameName);
            MultiPlayerWindowGame multiPlayerGame = new MultiPlayerWindowGame(vm);
            multiPlayerGame.Show();
        }
    }
}
