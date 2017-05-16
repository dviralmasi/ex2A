﻿using System;
using System.Collections.Generic;
using MazeLib;
using MazeGeneratorLib;
using SearchAlgorithmsLib;

namespace ObjectAdapter
{
    /// <summary>
    /// class for main.
    /// </summary>
    class Program
    {
        /// <summary>
        /// main method of objectadapter
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();
            program.compareSolvers();
        }
        /// <summary>
        /// compare the slovers.
        /// </summary>
        public void compareSolvers()
        {
            DFSMazeGenerator mazeCreator = new DFSMazeGenerator();
            Maze maze = mazeCreator.Generate(25, 25);
            MazeSearcher mazeSearchable = new MazeSearcher(maze);
            // dfs 
            Searcher<Position> dfsAlgo = new Dfs<Position>();
             Solution<Position> sol1 = dfsAlgo.search(mazeSearchable);
            Console.WriteLine(dfsAlgo.getNumberOfNodesEvaluated());
            List<State<Position>> pathdfs = sol1.getList();
            // bfs
            Searcher<Position> bfsAlgo = new Bfs<Position>();
           // MazeSearcher mazeSearchable = new MazeSearcher(maze);
            Solution<Position> sol2 = bfsAlgo.search(mazeSearchable);
            Console.WriteLine(bfsAlgo.getNumberOfNodesEvaluated());
            List<State<Position>> pathbfs = sol2.getList();
            foreach (State<Position> s in pathdfs)
            {
                int x = s.getState().Row;
                int y = s.getState().Col;
                
                Console.Write("({0},{1}), ", x, y);
            }
            Console.WriteLine();
            // convert maze to string before the print
            String mazeString = maze.ToString();
            Console.WriteLine(mazeString);
            Console.WriteLine();
            foreach (State<Position> s in pathbfs)
            {
                int x = s.getState().Row;
                int y = s.getState().Col;
                Console.Write("({0},{1}) ", x, y);
            }
            Console.ReadKey();
            
        }
    }
}
