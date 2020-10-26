using MarsRover.Houston.Enums;
using MarsRover.Houston.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Houston
{
    public class HoustonHelper
    {
        public static Dictionary<Direction, List<(RoverMove, Func<Rover, Rover>)>> rules
            = new Dictionary<Direction, List<(RoverMove, Func<Rover, Rover>)>>
            {
                [Direction.N] = new List<(RoverMove, Func<Rover, Rover>)>
            {
                (RoverMove.M, MoveNorth),
                (RoverMove.L, SpinLeft),
                (RoverMove.R, SpinRight)
            },
                [Direction.E] = new List<(RoverMove, Func<Rover, Rover>)>
            {
                (RoverMove.M, MoveEast),
                (RoverMove.L, SpinLeft),
                (RoverMove.R, SpinRight)
            },
                [Direction.S] = new List<(RoverMove, Func<Rover, Rover>)>
            {
                (RoverMove.M, MoveSouth),
                (RoverMove.L, SpinLeft),
                (RoverMove.R, SpinRight)
            },
                [Direction.W] = new List<(RoverMove, Func<Rover, Rover>)>
            {
                (RoverMove.M, MoveWest),
                (RoverMove.L, SpinLeft),
                (RoverMove.R, SpinRight)
            }
            };

        public static Rover Move(Rover rover)
        {
            foreach (var roverMove in rover.RoverMoves)
            {
                CanRoverMove(rover, roverMove);

                var rule = rules[rover.CurrentDirection].FirstOrDefault(x => x.Item1 == roverMove);

                rule.Item2(rover);
            }

            return rover;
        }

        private static Rover MoveNorth(Rover rover)
        {
            rover.CurrentCoordinate.Y++;

            return rover;
        }

        private static Rover MoveEast(Rover rover)
        {
            rover.CurrentCoordinate.X++;

            return rover;
        }

        private static Rover MoveSouth(Rover rover)
        {
            rover.CurrentCoordinate.Y--;

            return rover;
        }

        private static Rover MoveWest(Rover rover)
        {
            rover.CurrentCoordinate.X--;

            return rover;
        }

        private static Rover SpinLeft(Rover rover)
        {
            switch (rover.CurrentDirection)
            {
                case Direction.N:
                    rover.CurrentDirection = Direction.W;
                    break;
                case Direction.S:
                    rover.CurrentDirection = Direction.E;
                    break;
                case Direction.E:
                    rover.CurrentDirection = Direction.N;
                    break;
                case Direction.W:
                    rover.CurrentDirection = Direction.S;
                    break;
                default:
                    break;
            }

            return rover;
        }

        private static Rover SpinRight(Rover rover)
        {
            switch (rover.CurrentDirection)
            {
                case Direction.N:
                    rover.CurrentDirection = Direction.E;
                    break;
                case Direction.S:
                    rover.CurrentDirection = Direction.W;
                    break;
                case Direction.E:
                    rover.CurrentDirection = Direction.S;
                    break;
                case Direction.W:
                    rover.CurrentDirection = Direction.N;
                    break;
                default:
                    break;
            }

            return rover;
        }

        private static void CanRoverMove(Rover rover, RoverMove roverMove)
        {
            if (roverMove != RoverMove.M)
            {
                return;
            }

            if (rover.CurrentCoordinate.X > rover.Plateau.X || rover.CurrentCoordinate.Y > rover.Plateau.Y)
            {
                throw new Exception("Plateau limitleri aşılacak. Rover durduruldu.");
            }

        }

        public static List<RoverMove> ConvertCommandToRoverMoves(string command)
        {
            var roverMoves = new List<RoverMove>();

            var splitedCommand = command.ToCharArray().Select(x => x.ToString()).ToList();

            foreach (var item in splitedCommand)
            {
                if (Enum.TryParse(typeof(RoverMove), item, out var roverMove))
                {
                    roverMoves.Add((RoverMove)roverMove);
                }
                else
                {
                    throw new Exception("Komut içerisindeki hareket gerçekleştirilemiyor.");
                }
            }

            return roverMoves;
        }
    }
}
