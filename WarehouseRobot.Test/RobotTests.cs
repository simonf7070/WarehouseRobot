using NUnit.Framework;

namespace WarehouseRobot.Test
{
    [TestFixture]
    public class RobotTests
    {
        [Test]
        public void RobotThatDoesNotMoveIsInSamePosition()
        {
            var expectedPosition = string.Format("0 0 N");
            var robot = new Robot(0, 0, 'N');
            Assert.That(robot.Position, Is.EqualTo(expectedPosition));
        }

        [Test]
        public void RobotThatDoesNotMoveIsInSamePositionWithDifferentX()
        {
            var expectedPosition = string.Format("3 0 N");
            var robot = new Robot(3, 0, 'N');
            Assert.That(robot.Position, Is.EqualTo(expectedPosition));
        }

        [Test]
        public void RobotThatDoesNotMoveIsInSamePositionWithDifferentY()
        {
            var expectedPosition = string.Format("0 5 N");
            var robot = new Robot(0, 5, 'N');
            Assert.That(robot.Position, Is.EqualTo(expectedPosition));
        }

        [Test]
        public void RobotThatDoesNotMoveIsInSamePositionWithDifferentOrientation()
        {
            var expectedPosition = string.Format("3 5 E");
            var robot = new Robot(3, 5, 'E');
            Assert.That(robot.Position, Is.EqualTo(expectedPosition));
        }
    }
}
