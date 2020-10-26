using System;

namespace MarsRover.Houston.Models
{
    public class Plateau
    {
        public Plateau(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new Exception($"Plateau limitleri pozitif olmalıdır.");
            }

            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
