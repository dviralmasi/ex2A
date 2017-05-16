using GUI.ViewModel;
using MazeLib;
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

namespace GUI.ViewClient
{
    /// <summary>
    /// Interaction logic for SinglePlayerMaze.xaml.
    /// </summary>
    public partial class MazePlayer : UserControl
    {
        private SinglePlayerViewModel vm;
        public MazePlayer()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel();
            DataContext = vm;
        }

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty RowsProperty =
         DependencyProperty.Register("Rows", typeof(int), typeof(MazePlayer), new
        PropertyMetadata(0));

        public int Cols
        {
            get { return (int)GetValue(ColProperty); }
            set { SetValue(ColProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty ColProperty =
         DependencyProperty.Register("Cols", typeof(int), typeof(MazePlayer), new
        PropertyMetadata(0));

        public Maze Maze
        {
            get { return (Maze)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty MazeProperty =
         DependencyProperty.Register("Maze", typeof(int), typeof(MazePlayer), new
        PropertyMetadata(0));

        //like constructor
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //exeCommand("generate");
            double high = canvas.ActualHeight;
            double width = canvas.ActualWidth;
            double rectWidth = width / Cols;
            double recthigh = high / Rows;
            for (int i=0; i< Rows; i++)
            {
                for (int j=0; j<Cols; j++)
                {
                    if (Maze[i,j] == MazeLib.CellType.Wall)
                    {
                        Path path = new Path()
                        {
                            Data = new RectangleGeometry(new Rect(j * rectWidth, i * recthigh, rectWidth, recthigh)),
                            Fill = Brushes.Black,
                            Stroke = Brushes.PaleVioletRed
                        };
                        canvas.Children.Add(path);
                    }
                }
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
           // e.Key
        }
    }
}
