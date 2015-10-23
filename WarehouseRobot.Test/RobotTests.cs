using NUnit.Framework;

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
            var robot = new Robot(x, y, orientation);
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
            var robot = new Robot(x, y, orientation);
            robot.ProcessCommands(">");
            return robot.Position;
        }
        
        [TestCase(0, 0, 'N', ExpectedResult = "0 1 N")]
        [TestCase(0, 0, 'E', ExpectedResult = "1 0 E")]
        [TestCase(0, 1, 'S', ExpectedResult = "0 0 S")]
        [TestCase(1, 0, 'W', ExpectedResult = "0 0 W")]
        public string RobotFacingMovesForwardOnce(int x, int y, char orientation)
        {
            var robot = new Robot(x, y, orientation);
            robot.ProcessCommands("^");
            return robot.Position;
        }

        [Test]
        public void RobotFacingNorthMovesForwardTwice()
        {
            var robot = new Robot(0, 0, 'N');
            robot.ProcessCommands("^^");
            Assert.That(robot.Position, Is.EqualTo("0 2 N"));
        }

        [Test]
        public void RobotFacingNorthTurnsLeftThenMovesForward()
        {
            var robot = new Robot(1, 0, 'N');
            robot.ProcessCommands("<^");
            Assert.That(robot.Position, Is.EqualTo("0 0 W"));
        }

        [Test]
        public void RobotFollowsCommandSequence_InputOne()
        {
            var robot = new Robot(1, 2, 'N');
            robot.ProcessCommands("<^<^<^<^^");
            Assert.That(robot.Position, Is.EqualTo("1 3 N"));
        }

        [Test]
        public void RobotFollowsCommandSequence_InputTwo()
        {
            var robot = new Robot(3, 3, 'E');
            robot.ProcessCommands("^^>^^>^>>^");
            Assert.That(robot.Position, Is.EqualTo("5 1 E"));
        }
    }
}
