using MarsRover.Houston;
using MarsRover.Houston.Enums;
using MarsRover.Houston.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void StartPosition_12N_Move_LMLMLMLMMLM_Plateau_55()
        {
            const string expected = "0 3 W";

            var command = "LMLMLMLMMLM";

            var roverMoves = HoustonHelper.ConvertCommandToRoverMoves(command);

            var rover = new Rover(new Plateau(5, 5))
            {
                CurrentCoordinate = new Coordinate { X = 1, Y = 2 },
                CurrentDirection = Direction.N,
                RoverMoves = roverMoves
            };

            HoustonHelper.Move(rover);

            var actual = rover.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartPosition_33E_Move_MMRMMRMRRM_Plateau_55()
        {
            const string expected = "5 1 E";

            var command = "MMRMMRMRRM";

            var roverMoves = HoustonHelper.ConvertCommandToRoverMoves(command);

            var rover = new Rover(new Plateau(5, 5))
            {
                CurrentCoordinate = new Coordinate { X = 3, Y = 3 },
                CurrentDirection = Direction.E,
                RoverMoves = roverMoves
            };

            HoustonHelper.Move(rover);

            var actual = rover.Position;

            Assert.AreEqual(expected, actual);
        }
    }
}
