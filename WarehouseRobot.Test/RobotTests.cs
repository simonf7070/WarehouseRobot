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

        [Test]
        public void RobotTurnsLeftWithoutMovingStartFacingNorth()
        {
            var robot = new Robot(0, 0, 'N');
            robot.TurnLeft();
            Assert.That(robot.Position, Is.EqualTo("0 0 W"));
        }

        [Test]
        public void RobotTurnsLeftWithoutMovingStartFacingEast()
        {
            var robot = new Robot(0, 0, 'E');
            robot.TurnLeft();
            Assert.That(robot.Position, Is.EqualTo("0 0 N"));
        }

        [Test]
        public void RobotTurnsLeftWithoutMovingStartFacingSouth()
        {
            var robot = new Robot(0, 0, 'S');
            robot.TurnLeft();
            Assert.That(robot.Position, Is.EqualTo("0 0 E"));
        }

        [Test]
        public void RobotTurnsLeftWithoutMovingStartFacingWest()
        {
            var robot = new Robot(0, 0, 'W');
            robot.TurnLeft();
            Assert.That(robot.Position, Is.EqualTo("0 0 S"));
        }
    }
}
