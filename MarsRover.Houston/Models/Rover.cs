using MarsRover.Houston.Enums;
using System.Collections.Generic;

namespace MarsRover.Houston.Models
{
    public class Rover
    {
        public Rover(Plateau plateau)
        {
            Plateau = plateau;
        }

        public List<RoverMove> RoverMoves { get; set; }
        public Coordinate CurrentCoordinate { get; set; }
        public Direction CurrentDirection { get; set; }
        public Plateau Plateau { get; }

        public string Position => $"{CurrentCoordinate.X} {CurrentCoordinate.Y} {CurrentDirection.ToString()}";
    }
}
