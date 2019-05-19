using LabyrinthGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerationMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            LabyrinthGenerator.LabyrinthGenerator generator = new LabyrinthGenerator.LabyrinthGenerator();
            generator.DisplayFunction = Display;
            Room[,] maze = generator.Generate(10, 10, 20);

        }

        static void Display(Room[,] maze)
        {
            int c = 0;

            for(int y = maze.GetLength(1) -1; y >= 0 ; y--)
            {
                for(int x = 0; x < maze.GetLength(0); x++)
                {
                    if (c % maze.GetLength(0) == 0)
                    {
                        Console.Write("\n");
                    }
                    c++;
                    if (maze[x, y].IsFirst)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if(maze[x, y].IsLast)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (maze[x, y].IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(maze[x,y] + "|");
                    Console.ResetColor();
                }
            }
            Console.Write("\n");
            Console.ReadLine();
        }
    }
}
