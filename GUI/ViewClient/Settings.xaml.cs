using GUI.ClientModel;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
 
    public partial class Settings : Window
    {
        private SettingsViewModel vm;
        public Settings()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new ApplicationSettingsModel());
            this.DataContext = vm;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            MainWindow win = new MainWindow();
            win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
