using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ClientModel
{
    interface ISinglePlayerModel : INotifyPropertyChanged
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
        string MazeString { get; set; }

       // string ServerIP { get; set; }
       // int ServerPort { get; set; }
       // int SearchAlgorithm { get; set; }
      //  void SaveSettings();

        string generateCommand();
        string solve(string strSolve);

    }
}
