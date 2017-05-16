using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUI.ClientModel
{
    class ApplicationSinglePlayerModel: ISinglePlayerModel
    {
        private string mazeName;
        private int mazeRows;
        private int mazeCols;
        private string myMission;
        private Position initialPosition;
        private Maze maze;
        private NetworkStream stream = null;
        private StreamWriter writer = null;
        private StreamReader reader = null;
        private int port;
        IPEndPoint ep;
        TcpClient client;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
        public string MazeName {
            get { return mazeName; }
            set { mazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }
         public int MazeRows {
            get { return mazeRows; }
            set { mazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
         public int MazeCols {
            get { return mazeCols; }
            set { mazeCols = value;
                NotifyPropertyChanged("MazeCols");
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
        

        /// <summary>
        ///  if we in multiplayer make it true
        /// </summary>
        private bool isMultiPlayer = false;


        /// <summary>
        /// constructor of client
        /// </summary>
        public ApplicationSinglePlayerModel() {
            port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            client = new TcpClient();
        }

        public string generateCommand()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("generate ");
            sb.Append(mazeName.ToString());
            sb.Append(" " + MazeRows.ToString());
            sb.Append(" " + MazeCols.ToString());
            myMission = sb.ToString();
            string result = reader.ReadLine();
            return result;
        }


        /// <summary>
        /// start game method acting the single and the multi game
        /// </summary>
        public void startGame()
        {   
            //the main while loop keep ask for the next mission
            while (true)
            {
                ////first usr give his choice
                //Console.Write("Please enter a mission:");
                ////read from user
                //string mission = Console.ReadLine();
                //if client is off
                if (!client.Connected)
                {
                    Console.WriteLine("Im not connect yet");
                    try
                    {
                        //open and connect
                        client = new TcpClient();
                        client.Connect(ep);
                        Console.WriteLine("now im connect");
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("Error in socket");
                    }
                    Console.WriteLine("You are connected");
                    stream = client.GetStream();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream);
                }
                // Send data to server
                //split the input and check
                string[] arr = myMission.Split(' ');
                if (arr[0].Equals("start") || arr[0].Equals("join"))
                {
                    // to know if we need new thread
                    isMultiPlayer = true;
                }
                //send the mission to handle
               // string mission = generateCommand();
                writer.WriteLine(myMission);
                writer.Flush();
                //while for reading all the result
                while (true)
                {
                    string result = reader.ReadLine();

                }
                //if we need multiplayer mode open 2 tasks one to read and one more to write at same time
                if (isMultiPlayer)
                {
                    Task sendingTask = new Task(() =>
                    {
                        //to keep the task open
                        while (true)
                        {
                            // Send data to server
                            myMission = Console.ReadLine();
                            writer.WriteLine(myMission);
                            writer.Flush();
                        }

                    });

                    Task listenTask = new Task(() =>
                    {
                        while (true)
                        {
                            while (true)
                            {
                                // read the string from the buffer and print it
                                string result = reader.ReadLine();
                                // case we get empty Json-> it's for close command
                                if (result == "{}")
                                {
                                    // close the connection and close the stream
                                    client.Close();
                                    stream.Dispose();
                                    reader.Dispose();
                                    writer.Dispose();
                                    // create new connection
                                    client = new TcpClient();
                                    client.Connect(ep);
                                    Console.WriteLine("You are connected");
                                    // get new stream
                                    stream = client.GetStream();
                                    reader = new StreamReader(stream);
                                    writer = new StreamWriter(stream);
                                    break;
                                }
                                // if the input is not null, then print it
                                if (result != null)
                                {
                                    Console.WriteLine("{0}", result);
                                    if (reader.Peek() == '@')
                                    {
                                        result.TrimEnd('\n');
                                        break;
                                    }
                                }
                                else
                                {
                                    Thread.Sleep(1000);
                                }

                            }
                            reader.DiscardBufferedData();
                        }
                    });
                    //start the tasks and wait for them
                    sendingTask.Start();
                    listenTask.Start();
                    sendingTask.Wait();
                    listenTask.Wait();
                }
                else
                {
                    //if single player close connection
                    client.Close();
                    stream.Dispose();
                    writer.Dispose();
                    reader.Dispose();
                }
            }
        }
    }
}
