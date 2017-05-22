using MazeLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ClientModel
{
    public class ApplicationMultiPlyaerModel : IMultiPlayerModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string mazeName;
        private int mazeRows;
        private int mazeCols;
        private string myMission;
        private NetworkStream stream = null;
        private StreamWriter writer = null;
        private StreamReader reader = null;
        private int port;
        IPEndPoint ep;
        TcpClient client;
        private Maze maze;
        private Position initialPosition;
        private Position currentPosition;
        private Position endPosition;
        private ObservableCollection<string> listOfGames;



        /// <summary>
        /// constructor of multiPlayer
        /// </summary>
        public ApplicationMultiPlyaerModel()
        {
            // create port and IP
            port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            mazeRows = Properties.Settings.Default.MazeRows;
            mazeCols = Properties.Settings.Default.MazeCols;
        }


        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<string> ListGames
        {
            get { return listOfGames; }
            set
            {
                listOfGames = value;
                NotifyPropertyChanged("ListGames");
            }
        }

        public string MazeName
        {
            get { return mazeName; }
            set
            {
                mazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }
        public int MazeRows
        {
            get { return mazeRows; }
            set
            {
                mazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get { return mazeCols; }
            set
            {
                mazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        public Position InitialPosition
        {
            get { return initialPosition; }
            set
            {
                initialPosition = value;
                NotifyPropertyChanged("InitialPosition");
            }
        }

        public Position CurrentPosition
        {
            get { return currentPosition; }
            set
            {
                currentPosition = value;
                NotifyPropertyChanged("CurrentPosition");
            }
        }

        public Position EndPosition
        {
            get { return endPosition; }
            set
            {
                endPosition = value;
                NotifyPropertyChanged("EndPosition");
            }
        }



        public void openConnection()
        {
            client = new TcpClient();
            client.Connect(ep);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public void CloseConnection()
        {
            // close the connection and close the stream
            client.Close();
            stream.Dispose();
            reader.Dispose();
            writer.Dispose();
        }

        public string startCommand (string startStr)
        {
            openConnection();
            myMission = startStr;
            writer.WriteLine(myMission);
            writer.Flush();
            //// read all result
            string result = reader.ReadLine();
            while (true)
            {
                Console.WriteLine("{0}", result);
                // we add '@' char for each string that we want to print, and stop the printing 
                // when we arrive this char.
                if (reader.Peek() == '@')
                {
                    result.TrimEnd('\n');
                    break;
                }
                result += reader.ReadLine();
            }

            reader.DiscardBufferedData();
            return result;
        }

        public string joinCommand(string startStr)
        {
            openConnection();
            myMission = startStr;
            writer.WriteLine(myMission);
            writer.Flush();
            //// read all result
            string result = reader.ReadLine();
            while (true)
            {
                Console.WriteLine("{0}", result);
                // we add '@' char for each string that we want to print, and stop the printing 
                // when we arrive this char.
                if (reader.Peek() == '@')
                {
                    result.TrimEnd('\n');
                    break;
                }
                result += reader.ReadLine();
            }
            reader.DiscardBufferedData();
            return result;
        }

        public void ListCommand()
        {
            openConnection();
            StringBuilder sb = new StringBuilder();
            sb.Append("list");
            myMission = sb.ToString();
            writer.WriteLine(myMission);
            writer.Flush();
            //// read all result
            string result = reader.ReadLine();
            while (true)
            {
                Console.WriteLine("{0}", result);
                // we add '@' char for each string that we want to print, and stop the printing 
                // when we arrive this char.
                if (reader.Peek() == '@')
                {
                    result.TrimEnd('\n');
                    break;
                }
                result += reader.ReadLine();                            
            }
            reader.DiscardBufferedData();
            ListGames = JsonConvert.DeserializeObject<ObservableCollection<string>>(result);
            CloseConnection();
        }
    }
}
