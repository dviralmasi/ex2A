using GUI.ClientModel;
using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewModel
{
    public class SinglePlayerViewModel : ViewModel
    {
        private ISinglePlayerModel model;
       // private Maze mazeDraw;
        public SinglePlayerViewModel()
        {
            model = new ApplicationSinglePlayerModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        public string MazeNames
        {
            get { return model.MazeName; }
            set
            {
                model.MazeName = value;
            }
        }
        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
            }
        }
        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
            }
        }

        public string MazeStrings
        {
            get { return model.MazeString; }
            set
            {
                model.MazeString = value;
            }
        }

        public Maze MyMaze
        {
            get { return model.Maze; }
            set
            {
                model.Maze = value;
            }
        }

        public Position InitialPosition
        {
            get { return model.InitialPosition; }
            set
            {
                model.InitialPosition = value;
            }
        }

        public Position CurrentPosition
        {
            get { return model.CurrentPosition; }
            set
            {
                model.CurrentPosition = value;
            }
        }

        public Position EndPosition
        {
            get { return model.EndPosition; }
            set
            {
                model.EndPosition = value;
            }
        }

        public void exeCommand(string command)
        {
            string strMaze = null;
            switch (command)
            {
                case "generate": strMaze = model.generateCommand();
                    break;
                default: break;
            }

            // convert the json to maze object
           // string strMaze = model.generateCommand();
            MyMaze = Maze.FromJSON(strMaze);
            // update properties 
            MazeRows = MyMaze.Rows;
            MazeCols = MyMaze.Cols;
            MazeNames = MyMaze.Name;
            InitialPosition = MyMaze.InitialPos;
            // update current position to the start point in maze
            CurrentPosition = MyMaze.InitialPos;
            EndPosition = MyMaze.GoalPos;
        }

        public string solveCommand()
        {
            string strSolve = model.solve("solve " + MazeNames.ToString() + " " + Properties.Settings.Default.SearchAlgorithm.ToString());
            JObject obj = JObject.Parse(strSolve);
            string strSol = (string)obj["Solution"];
            return strSol;

        }
    }
}
