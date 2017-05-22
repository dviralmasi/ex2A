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
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;

namespace GUI.ViewClient
{
    /// <summary>
    /// Interaction logic for SinglePlayerMaze.xaml.
    /// </summary>
    public partial class MazePlayer : UserControl
    {
        private Position p = new Position();
        private Image player, dest;

        public MazePlayer()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
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
         DependencyProperty.Register("MazeName", typeof(string), typeof(MazePlayer));

        public Maze Mazes
        {
            get { return (Maze)GetValue(MazesProperty); }
            set { SetValue(MazesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty MazesProperty =
         DependencyProperty.Register("Mazes", typeof(Maze), typeof(MazePlayer));

        public string MazeString
        {
            get { return (string)GetValue(MazeStringProperty); }
            set { SetValue(MazeStringProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Rows. This enables animation, styling,
        public static readonly DependencyProperty MazeStringProperty =
         DependencyProperty.Register("MazeString", typeof(string), typeof(MazePlayer));



        public Position InitialPos
        {
            get { return (Position)GetValue(InitialPosProperty); }
            set { SetValue(InitialPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialPosProperty =
            DependencyProperty.Register("InitialPos", typeof(Position), typeof(MazePlayer));



        public Position CurrentPos
        {
            get { return (Position)GetValue(CurrentPosProperty); }
            set { SetValue(CurrentPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPosProperty =
            DependencyProperty.Register("CurrentPos", typeof(Position), typeof(MazePlayer));




        public Position EndPos
        {
            get { return (Position)GetValue(EndPosProperty); }
            set { SetValue(EndPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndPosProperty =
            DependencyProperty.Register("EndPos", typeof(Position), typeof(MazePlayer));





        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Window win = Window.GetWindow(this);
            win.KeyDown += canvas_KeyDown;
            p = InitialPos;
            double high = canvas.ActualHeight;
            double width = canvas.ActualWidth;
            double rectWidth = width / Cols;
            double recthigh = high / Rows;
            SolidColorBrush b = Brushes.Black;
            SolidColorBrush red = Brushes.Red;
            SolidColorBrush blue = Brushes.Blue;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (j == InitialPos.Col && i == InitialPos.Row)
                    {
                        player = new Image()
                        {
                            Source = new BitmapImage(new Uri(@"C:\Users\USER\Documents\ex2A\GUI\resources\keep-walking.jpg")),
                            Width = rectWidth,
                            Height = recthigh,
                        };
                        Canvas.SetLeft(player, InitialPos.Col * rectWidth);
                        Canvas.SetTop(player, InitialPos.Row * recthigh);
                        canvas.Children.Add(player);
                    }

                    if (j == EndPos.Col && i == EndPos.Row)
                    {
                        dest = new Image()
                        {
                            Source = new BitmapImage(new Uri(@"C:\Users\USER\Documents\ex2A\GUI\resources\shampine.jpg")),
                            Width = rectWidth,
                            Height = recthigh,
                        };
                        Canvas.SetLeft(dest, EndPos.Col * rectWidth);
                        Canvas.SetTop(dest, EndPos.Row * recthigh);
                        canvas.Children.Add(dest);
                    }

                    if (Mazes[i, j] == CellType.Wall)
                    {
                        Path path = new Path()
                        {
                            Data = new RectangleGeometry(new Rect(j * rectWidth, i * recthigh, rectWidth, recthigh)),
                            Fill = b,
                        };
                        canvas.Children.Add(path);
                    }
                }
            }
        }


        public void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            // handle in button
            switch (e.Key)
            {
                case Key.Up:
                    if ((p.Row - 1 >= 0) && (Mazes[p.Row - 1, p.Col] != CellType.Wall))
                    {
                        p.Row = p.Row - 1;
                        CurrentPos = p;
                        updatePosition();
                    }
                    break;

                case Key.Down:
                    if ((p.Row + 1 < Rows) && (Mazes[p.Row + 1, p.Col] != CellType.Wall))
                    {
                        p.Row = p.Row + 1;
                        CurrentPos = p;
                        updatePosition();
                    }
                    break;

                case Key.Right:
                    if ((p.Col + 1 < Cols) && (Mazes[p.Row, p.Col + 1] != CellType.Wall)) 
                    {
                        p.Col = p.Col + 1;
                        CurrentPos = p;
                        updatePosition();
                    }
                    break;

                case Key.Left:
                    if ((p.Col - 1 >= 0) && (Mazes[p.Row, p.Col - 1] != CellType.Wall))
                    {
                        p.Col = p.Col - 1;
                        CurrentPos = p;
                        updatePosition();
                    }
                    break;

                default: break;
            }
        }

        public void updatePosition()
        {
            double rectWidth = canvas.ActualWidth / Cols;
            double recthigh = canvas.ActualHeight / Rows;
            
            Canvas.SetLeft(player, CurrentPos.Col * rectWidth);
            Canvas.SetTop(player, CurrentPos.Row * recthigh);
        }

        public void updateToStartPos()
        {
            double rectWidth = canvas.ActualWidth / Cols;
            double recthigh = canvas.ActualHeight / Rows;

            Canvas.SetLeft(player, InitialPos.Col * rectWidth);
            Canvas.SetTop(player, InitialPos.Row * recthigh);
            p.Row = InitialPos.Row;
            p.Col = InitialPos.Col;
            CurrentPos = p;   
        }


        public void SolveAnimation(string sol)
        {
            //Application.Current.Dispatcher.Invoke(new Action(()=> 
            //{
            //update to initial position and then move it on the screen
            p = InitialPos;
            CurrentPos = InitialPos;
            Canvas.SetLeft(player, CurrentPos.Col * canvas.ActualWidth / Cols);
            Canvas.SetTop(player, CurrentPos.Row * canvas.ActualHeight / Rows);

            CharEnumerator ch = sol.GetEnumerator();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += delegate (object sender, EventArgs e)
            {
                if (ch.MoveNext())
                {
                    if (ch.Current == '0')
                    {
                        // left
                        p.Col--;
                        CurrentPos = p;
                        Canvas.SetLeft(player, CurrentPos.Col * canvas.ActualWidth / Cols);
                        Canvas.SetTop(player, CurrentPos.Row * canvas.ActualHeight / Rows);
                    }
                    if (ch.Current == '1')
                    {
                        // left
                        p.Col++;
                        CurrentPos = p;
                        Canvas.SetLeft(player, CurrentPos.Col * canvas.ActualWidth / Cols);
                        Canvas.SetTop(player, CurrentPos.Row * canvas.ActualHeight / Rows);
                    }
                    if (ch.Current == '2')
                    {
                        // left
                        p.Row--;
                        CurrentPos = p;
                        Canvas.SetLeft(player, CurrentPos.Col * canvas.ActualWidth / Cols);
                        Canvas.SetTop(player, CurrentPos.Row * canvas.ActualHeight / Rows);
                    }
                    if (ch.Current == '3')
                    {
                        // left
                        p.Row++;
                        CurrentPos = p;
                        Canvas.SetLeft(player, CurrentPos.Col * canvas.ActualWidth / Cols);
                        Canvas.SetTop(player, CurrentPos.Row * canvas.ActualHeight / Rows);
                    }
                } else
                {
                    timer.Stop();
                }
                };
            timer.Interval = TimeSpan.FromSeconds(0.2);
            timer.Start();
        }
    }
}