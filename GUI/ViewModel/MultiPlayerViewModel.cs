using GUI.ClientModel;
using MazeLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    public class MultiPlayerViewModel : ViewModel
    {
        private IMultiPlayerModel model;

        public MultiPlayerViewModel()
        {
            this.model = new ApplicationMultiPlyaerModel();
            // this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
            model.ListCommand();
        }

        // properties
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

        public ObservableCollection<string> ListGames
        {
            get { return model.ListGames; }
            set
            {
                model.ListGames = value;
            }
        }

        public void StartGame()
        {
            string strMaze = model.startCommand("start " + MazeNames.ToString() + " " + MazeRows.ToString() + " " + MazeCols.ToString());
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

        public void JoinGame(string gameName)
        {
            MazeNames = gameName;
            string strMaze = model.joinCommand("join " + MazeNames.ToString());
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

        //public void ListOfGames()
        //{
        //    string strList = model.ListCommand();
        //    ListGames = JsonConvert.DeserializeObject<ObservableCollection<string>>(strList); 
        //    // convert the json to list

        //}

    }
}
