﻿using Moq;
using NUnit.Framework;

namespace WarehouseRobot.Test
{
    [TestFixture]
    public class RobotTests
    {
        private Mock<IWarehouse> _warehouse;

        [TestFixtureSetUp]
        public void Init()
        {
            _warehouse = new Mock<IWarehouse>();
            _warehouse.Setup(w => w.IsValidCoordinate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        }

        [TestCase(0, 0, 'N')]
        [TestCase(0, 0, 'E')]
        [TestCase(0, 0, 'S')]
        [TestCase(0, 0, 'W')]
        [TestCase(3, 5, 'E')]
        public void RobotThatDoesNotMoveIsInOriginalPosition(int x, int y, char orientation)
        {
            var expectedPosition = string.Format("{0} {1} {2}", x, y, orientation);
            var robot = new Robot(_warehouse.Object, x, y, orientation);
            Assert.That(robot.Position, Is.EqualTo(expectedPosition));
        }
        
        [TestCase(0, 0, 'N', ExpectedResult = "0 0 W")]
        [TestCase(0, 0, 'E', ExpectedResult = "0 0 N")]
        [TestCase(0, 0, 'S', ExpectedResult = "0 0 E")]
        [TestCase(0, 0, 'W', ExpectedResult = "0 0 S")]
        [TestCase(3, 5, 'W', ExpectedResult = "3 5 S")]
        public string RobotTurnsLeftWithoutMoving(int x, int y, char orientation)
        {
            var robot = new Robot(_warehouse.Object, x, y, orientation);
            robot.ProcessCommands("<");
            return robot.Position;
        }

        [TestCase(0, 0, 'N', ExpectedResult = "0 0 S")]
        [TestCase(0, 0, 'E', ExpectedResult = "0 0 W")]
        [TestCase(0, 0, 'S', ExpectedResult = "0 0 N")]
        [TestCase(0, 0, 'W', ExpectedResult = "0 0 E")]
        [TestCase(3, 5, 'W', ExpectedResult = "3 5 E")]
        public string RobotTurnsLeftTwiceWithoutMoving(int x, int y, char orientation)
        {
            var robot = new Robot(_warehouse.Object, x, y, orientation);
            robot.ProcessCommands("<<");
            return robot.Position;
        }

        [TestCase(0, 0, 'N', ExpectedResult = "0 0 E")]
        [TestCase(0, 0, 'E', ExpectedResult = "0 0 S")]
        [TestCase(0, 0, 'S', ExpectedResult = "0 0 W")]
        [TestCase(0, 0, 'W', ExpectedResult = "0 0 N")]
        [TestCase(3, 5, 'W', ExpectedResult = "3 5 N")]
        public string RobotTurnsRightWithoutMoving(int x, int y, char orientation)
        {
            var robot = new Robot(_warehouse.Object, x, y, orientation);
            robot.ProcessCommands(">");
            return robot.Position;
        }
        
        [TestCase(0, 0, 'N', ExpectedResult = "0 1 N")]
        [TestCase(0, 0, 'E', ExpectedResult = "1 0 E")]
        [TestCase(0, 1, 'S', ExpectedResult = "0 0 S")]
        [TestCase(1, 0, 'W', ExpectedResult = "0 0 W")]
        public string RobotFacingMovesForwardOnce(int x, int y, char orientation)
        {
            var robot = new Robot(_warehouse.Object, x, y, orientation);
            robot.ProcessCommands("^");
            return robot.Position;
        }

        [Test]
        public void RobotFacingNorthMovesForwardTwice()
        {
            var robot = new Robot(_warehouse.Object, 0, 0, 'N');
            robot.ProcessCommands("^^");
            Assert.That(robot.Position, Is.EqualTo("0 2 N"));
        }

        [Test]
        public void RobotFacingNorthTurnsLeftThenMovesForward()
        {
            var robot = new Robot(_warehouse.Object, 1, 0, 'N');
            robot.ProcessCommands("<^");
            Assert.That(robot.Position, Is.EqualTo("0 0 W"));
        }

        [Test]
        public void RobotFollowsCommandSequence_InputOne()
        {
            var robot = new Robot(_warehouse.Object, 1, 2, 'N');
            robot.ProcessCommands("<^<^<^<^^");
            Assert.That(robot.Position, Is.EqualTo("1 3 N"));
        }

        [Test]
        public void RobotFollowsCommandSequence_InputTwo()
        {
            var robot = new Robot(_warehouse.Object, 3, 3, 'E');
            robot.ProcessCommands("^^>^^>^>>^");
            Assert.That(robot.Position, Is.EqualTo("5 1 E"));
        }

        [Test]
        public void RobotTriesToMoveOutsideOfWarehouseShouldNotMove()
        {
            var warehouse = new Mock<IWarehouse>();
            warehouse.Setup(w => w.IsValidCoordinate(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var robot = new Robot(warehouse.Object, 5, 5, 'N');
            warehouse.Setup(w => w.IsValidCoordinate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            robot.ProcessCommands("^");

            Assert.That(robot.Position, Is.EqualTo("5 5 N"));
        }

        [Test]
        [ExpectedException]
        public void RobotCreatedWithInvalidOrientation()
        {
            var robot = new Robot(_warehouse.Object, 0, 0, 'X');
        }

        [Test]
        [ExpectedException]
        public void RobotCreatedWithInvalidWarehouseLocation()
        {
            var warehouse = new Mock<IWarehouse>();
            warehouse.Setup(w => w.IsValidCoordinate(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            var robot = new Robot(warehouse.Object, 0, 0, 'N');
        }
    }
}
