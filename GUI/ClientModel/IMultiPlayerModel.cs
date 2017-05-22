using MazeLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ClientModel
{
    interface IMultiPlayerModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged(string propName);

        string MazeName { get; set; }
        int MazeRows { get; set; }
        int MazeCols { get; set; }
        Maze Maze { get; set; }
        Position InitialPosition { get; set; }
        Position CurrentPosition { get; set; }
        Position EndPosition { get; set; }
        ObservableCollection<string> ListGames { get; set; }
        //string MazeString { get; set; }
        string startCommand(string startStr);
        string joinCommand(string joinStr);
        void ListCommand();
    }
}
