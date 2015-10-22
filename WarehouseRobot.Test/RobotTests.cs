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
    }
}
