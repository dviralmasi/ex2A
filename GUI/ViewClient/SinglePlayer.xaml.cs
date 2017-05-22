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
using MazeLib;
using System.ComponentModel;
using System.Windows.Threading;

namespace GUI.ViewClient
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        private SinglePlayerViewModel vm;

        public SinglePlayer(SinglePlayerViewModel otherVm)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            InitializeComponent();
            
            this.vm = otherVm;
            this.DataContext = vm;
            
        }

        public void setVm(SinglePlayerViewModel otherVm)
        {
            this.vm = otherVm;
        }
        private void restart_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to restart game?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MazeUserControl.updateToStartPos();
            } 

     
        }

        private void SinglePlayer_Loaded(object sender, RoutedEventArgs e)
        {
            MazePlayer mazePlayer = new MazePlayer();
        }

        private void solveMaze_Click(object sender, RoutedEventArgs e)
        {
            string sol = vm.solveCommand();
            MazeUserControl.SolveAnimation(sol);
        
            

        }
    }
}