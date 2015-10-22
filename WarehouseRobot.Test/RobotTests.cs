﻿using NUnit.Framework;

namespace WarehouseRobot.Test
{
    [TestFixture]
    public class RobotTests
    {
        [TestCase(0, 0, 'N')]
        [TestCase(0, 0, 'E')]
        [TestCase(0, 0, 'S')]
        [TestCase(0, 0, 'W')]
        [TestCase(3, 5, 'E')]
        public void RobotThatDoesNotMoveIsInOriginalPosition(int x, int y, char orientation)
        {
            var expectedPosition = string.Format("{0} {1} {2}", x, y, orientation);
            var robot = new Robot(x, y, orientation);
            Assert.That(robot.Position, Is.EqualTo(expectedPosition));
        }
        
        [TestCase(0, 0, 'N', ExpectedResult = "0 0 W")]
        [TestCase(0, 0, 'E', ExpectedResult = "0 0 N")]
        [TestCase(0, 0, 'S', ExpectedResult = "0 0 E")]
        [TestCase(0, 0, 'W', ExpectedResult = "0 0 S")]
        [TestCase(3, 5, 'W', ExpectedResult = "3 5 S")]
        public string RobotTurnsLeftWithoutMoving(int x, int y, char orientation)
        {
            var robot = new Robot(x, y, orientation);
            robot.TurnLeft();
            return robot.Position;
        }

        [TestCase(0, 0, 'N', ExpectedResult = "0 0 S")]
        [TestCase(0, 0, 'E', ExpectedResult = "0 0 W")]
        [TestCase(0, 0, 'S', ExpectedResult = "0 0 N")]
        [TestCase(0, 0, 'W', ExpectedResult = "0 0 E")]
        [TestCase(3, 5, 'W', ExpectedResult = "3 5 E")]
        public string RobotTurnsLeftTwiceWithoutMoving(int x, int y, char orientation)
        {
            var robot = new Robot(x, y, orientation);
            robot.TurnLeft();
            robot.TurnLeft();
            return robot.Position;
        }

        [TestCase(0, 0, 'N', ExpectedResult = "0 0 E")]
        [TestCase(0, 0, 'E', ExpectedResult = "0 0 S")]
        [TestCase(0, 0, 'S', ExpectedResult = "0 0 W")]
        [TestCase(0, 0, 'W', ExpectedResult = "0 0 N")]
        [TestCase(3, 5, 'W', ExpectedResult = "3 5 N")]
        public string RobotTurnsRightWithoutMoving(int x, int y, char orientation)
        {
            var robot = new Robot(x, y, orientation);
            robot.TurnRight();
            return robot.Position;
        }

        [Test]
        public void RobotFacingNorthMovesForwardOnce()
        {
            var robot = new Robot(0, 0, 'N');
            robot.MoveForward();
            Assert.That(robot.Position, Is.EqualTo("0 1 N"));
        }

        [Test]
        public void RobotFacingEastMovesForwardOnce()
        {
            var robot = new Robot(0, 0, 'E');
            robot.MoveForward();
            Assert.That(robot.Position, Is.EqualTo("1 0 E"));
        }
    }
}
