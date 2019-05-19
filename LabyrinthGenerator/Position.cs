using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGenerator
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Position operator +(Position a, Position b)
        {
            return new Position
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }

        public bool IsInRange(int maxX, int maxY)
        {
            return !(X > maxX-1 || X < 0 || Y > maxY-1 || Y < 0);
        }


    }
}
