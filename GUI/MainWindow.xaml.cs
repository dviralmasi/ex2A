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
using GUI.ViewClient;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
           this.Close();
        }
       

        private void SinglePlayer_Click_1(object sender, RoutedEventArgs e)
        {
            MenuSinglePlayer singleManu = new MenuSinglePlayer();
            singleManu.Show();
            this.Close();
        }

        private void MultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayerMenu multiPlayer = new MultiPlayerMenu();
            multiPlayer.Show();
            this.Close();
        }
    }
}
