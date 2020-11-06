using MarsRover.Houston;
using MarsRover.Houston.Enums;
using MarsRover.Houston.Models;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine();

            var command = a.ToString();

            var roverMoves = HoustonHelper.ConvertCommandToRoverMoves(command);

            var rover = new Rover(new Plateau(5, 5))
            {
                CurrentCoordinate = new Coordinate { X = 1, Y = 2 },
                CurrentDirection = Direction.N,
                RoverMoves = roverMoves
            };

            HoustonHelper.Move(rover);

            var actual = rover.Position;

            Console.WriteLine(actual);

            Console.ReadKey();
        }
    }
}
