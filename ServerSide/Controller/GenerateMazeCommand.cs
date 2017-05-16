﻿using MazeLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// class GenerateMazeCommand impelement Icommand
    /// </summary>
    public class GenerateMazeCommand : ICommand
    {
        /// <summary>
        /// model
        /// </summary>
        private IModel model;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="model">my model</param>
        public GenerateMazeCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// implement
        /// </summary>
        /// <param name="args">args of action</param>
        /// <param name="client">client</param>
        /// <returns>string</returns>
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = model.generateMaze(name, rows, cols);
            return maze.ToJSON();
        }
    }
}
