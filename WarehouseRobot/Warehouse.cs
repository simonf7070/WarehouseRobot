using System;

namespace WarehouseRobot.Test
{
    public class Warehouse
    {
        private const int LowerX = 0;
        private const int LowerY = 0;
        private readonly int _upperX;
        private readonly int _upperY;

        public Warehouse(int upperX, int upperY)
        {
            if (upperX < LowerX)
            {
                throw new Exception("Invalid x dimension");
            }
            if (upperY < LowerY)
            {
                throw new Exception("Invalid y dimension");
            }
            _upperX = upperX;
            _upperY = upperY;
        }

        public bool IsValidCoordinate(int x, int y)
        {
            if (x > _upperX)
            {
                return false;
            }
            if (y > _upperY)
            {
                return false;
            }
            return true;
        }
    }
}