using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGenerator
{
    public class LabyrinthGenerator
    {
        List<Position> Directions = new List<Position>()
        {
            { new Position{ X=1, Y=0} },
            { new Position{ X=-1, Y=0} },
            { new Position{ X=0, Y=1} },
            { new Position{ X=0, Y=-1} },

        };

        public Action<Room[,]> DisplayFunction { get; set; }

        private void Initialize(Room[,] maze)
        {
            int roomNumber = 1;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = new Room
                    {
                        IsVisited = false,
                        Number = roomNumber,
                        IsFirst = false,
                        IsLast = false
                    };
                    roomNumber++;

                }
            }
        }
        public Room[,] Generate(int width = 5, int height = 5, int roomNumbers = 10)
        {
            Stack<Position> visitedRooms = new Stack<Position>();
            Room[,] maze = new Room[width, height];

            Initialize(maze);    

            Random rand = new Random();
            Position currentPos = new Position()
            {
                X = rand.Next(width),
                Y = rand.Next(height)
            };

            visitedRooms.Push(currentPos);
            maze[currentPos.X, currentPos.Y].IsVisited = true;
            maze[currentPos.X, currentPos.Y].IsFirst = true;

            DisplayFunction(maze);

            for (int i = 2; i < roomNumbers+1; i++)
            {
                Directions.Shuffle();
                int failedMove = 0;
                foreach (Position dir in Directions)
                {
                    if(!(currentPos + dir).IsInRange(width, height) || maze[(currentPos + dir).X, (currentPos + dir).Y ].IsVisited)
                    {
                        failedMove++;
                        if(failedMove == 4)
                        {
                            currentPos = visitedRooms.Pop();
                            i--;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        currentPos += dir;
                        visitedRooms.Push(currentPos);
                        maze[currentPos.X, currentPos.Y].IsVisited = true;
                        break;
                    }
                }
                if(i + 1 >= roomNumbers + 1)
                {
                    maze[currentPos.X, currentPos.Y].IsLast = true;
                }
                DisplayFunction(maze);
            }

            return maze;
        }
    }
}
