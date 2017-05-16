﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Adapter class for the Maze  implement isearchable
    /// </summary>
    public class MazeSearcher : ISearchable<Position>
    {
        /// <summary>
        /// mymaxe
        /// </summary>
        private Maze myMaze;
        /// <summary>
        /// start and goal
        /// </summary>
        private State<Position> myStart, myGoal;
        /// <summary>
        /// pool state
        /// </summary>
        HashSet<State<Position>> poolState;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maze"> maze to initialize</param>
        public MazeSearcher(Maze maze)
        {
            myMaze = maze;
            // create start state
            myStart = new State<Position>(myMaze.InitialPos);
            // create goal state
            myGoal = new State<Position>(myMaze.GoalPos);
            poolState = new HashSet<State<Position>>();
        }
        /// <summary>
        /// get start
        /// </summary>
        /// <returns>start point</returns>
        public State<Position> getInitialState()
        {
            return myStart;
        }
        /// <summary>
        /// get end point
        /// </summary>
        /// <returns>end</returns>
        public State<Position> getGoalState()
        {
            return myGoal;
        }
        /// <summary>
        /// check his all relevant niegbours
        /// </summary>
        /// <param name="s">check s neighbors</param>
        /// <returns> the list of them</returns>
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            List<State<MazeLib.Position>> myNeigbours = new List<State<MazeLib.Position>>();
            // up
            if ((s.getState().Row - 1 >= 0) && (myMaze[s.getState().Row - 1, s.getState().Col] == 0))
            {
                MazeLib.Position upPosition = new MazeLib.Position(s.getState().Row - 1, s.getState().Col);
                State<MazeLib.Position> up = new State<MazeLib.Position>(upPosition);
                up.CameFrom = s;
                myNeigbours.Add(up);
            }
            //right
            if ((s.getState().Col + 1 < myMaze.Cols) && (myMaze[s.getState().Row, s.getState().Col + 1] == 0))
            {
                MazeLib.Position rightPosition = new MazeLib.Position(s.getState().Row, s.getState().Col + 1);
                State<MazeLib.Position> right = new State<MazeLib.Position>(rightPosition);
                right.CameFrom = s;
                myNeigbours.Add(right);
            }
            // down
            if ((s.getState().Row + 1 < myMaze.Rows) && (myMaze[s.getState().Row + 1, s.getState().Col] == 0))
            {
                Position downPosition = new Position(s.getState().Row + 1, s.getState().Col);
                State<Position> down = new State<Position>(downPosition);
                down.CameFrom = s;
                myNeigbours.Add(down);
            }
            //left
            if ((s.getState().Col - 1 >= 0) && (myMaze[s.getState().Row, s.getState().Col - 1] == 0))
            {
                Position leftPosition = new Position(s.getState().Row, s.getState().Col - 1);
                State<Position> left = new State<Position>(leftPosition);
                left.CameFrom = s;
                myNeigbours.Add(left);
            }
            return myNeigbours;
        }

     /* public  State<Position> getStateFromPool(Position p)
        {
            if (poolState.Contains(p))
            poolState.Add(new State<Position>(p));
        }*/
    }
}
