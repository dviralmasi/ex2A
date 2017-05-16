using GUI.ClientModel;
using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    class SinglePlayerViewModel : ViewModel
    {
        private ISinglePlayerModel model;
        public SinglePlayerViewModel()
        {
            model = new ApplicationSinglePlayerModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        public string MazeName
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

        public string MazeString
        {
            get { return model.MazeString; }
            set
            {
                model.MazeString = value;
            }
        }

        public Maze Mazes
        {
            get { return model.Maze; }
            set
            {
                model.Maze = value;
            }
        }

        public Maze exeCommand(string command)
        {
            // convert the json to maze object
            string strMaze = model.generateCommand();
            Maze maze = Maze.FromJSON(strMaze);
            return maze;
        }
    }
}
