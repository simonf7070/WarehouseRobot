using System;
using System.Linq;

namespace WarehouseRobot.ConsoleApplication
{
    class RobotProgram
    {
        static void Main(string[] args)
        { 
            var gridSize = GetGridSize();
            var robotProgram = new RobotProgram();
            while (true)
            {
                robotProgram.Run();
            }
        }
        
        private void Run()
        {
            var startPosition = GetRobotStartingPosition();
            var commands = GetRobotCommands();

            var robot = new Robot(int.Parse(startPosition[0]), int.Parse(startPosition[1]), char.Parse(startPosition[2].ToUpper()));
            robot.ProcessCommands(commands);
            Console.WriteLine("Robots new position: " + robot.Position);
        }

        private static int[] GetGridSize()
        {
            Console.Write("Enter upper-right coordinates for warehouse: ");
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        private static string GetRobotCommands()
        {
            Console.Write("Enter robot commands: ");
            return Console.ReadLine();
        }

        private static string[] GetRobotStartingPosition()
        {
            Console.Write("Enter robot starting position: ");
            return Console.ReadLine().Split(' ').ToArray();
        }
    }
}
