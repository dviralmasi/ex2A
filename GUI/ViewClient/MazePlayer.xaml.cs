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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MazeLib;

namespace GUI.ViewClient
{
    /// <summary>
    /// Interaction logic for SinglePlayerMaze.xaml.
    /// </summary>
    public partial class MazePlayer : UserControl
    {
        public MazePlayer()
        {
            InitializeComponent();
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

        public string MazeName
        {
            get { return (string)GetValue(MazeNameProperty); }
            set { SetValue(MazeNameProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty MazeNameProperty =
         DependencyProperty.Register("MazeName", typeof(string), typeof(MazePlayer), new
        PropertyMetadata(0));

        public Maze Mazef
        {
            get { return (Maze)GetValue(MazefProperty); }
            set { SetValue(MazefProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty MazefProperty =
         DependencyProperty.Register("Mazef", typeof(Maze), typeof(MazePlayer), new
        PropertyMetadata(0));

        public string MazeString
        {
            get { return (string)GetValue(MazeStringProperty); }
            set { SetValue(MazeStringProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty MazeStringProperty =
         DependencyProperty.Register("MazeString", typeof(string), typeof(MazePlayer), new
        PropertyMetadata(0));


        public void doNothing()
        {
            //exeCommand("generate");
            double high = canvas.ActualHeight;
            double width = canvas.ActualWidth;
            double rectWidth = width / Cols;
            double recthigh = high / Rows;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (Mazef[i, j] == CellType.Wall)
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