using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthGenerator
{
    public class Room
    {
        public bool IsVisited { get; set; }
        public int Number { get; set; }
        public bool IsLast { get; set; }
        public bool IsFirst { get; set; }
        public override string ToString()
        {
            return $"{Number}";
        }

        public enum DoorsPosition
        {
            Top = 0x0,
            Bot = 0x1,
            Right = 0x2,
            Left = 0x4
        }

        public DoorsPosition Doors { get; set; }
    }
}
