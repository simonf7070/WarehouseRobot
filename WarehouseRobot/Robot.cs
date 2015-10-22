namespace WarehouseRobot
{
    public class Robot
    {    
        private readonly int _x;
        private readonly int _y;
        private char _orientation;

        public Robot(int startX, int startY, char startOrientation)
        {
            _x = startX;
            _y = startY;
            _orientation = startOrientation;
        }

        public string Position 
        {
            get { return string.Format("{0} {1} {2}", _x, _y, _orientation); }
        }

        public void TurnLeft()
        {
            switch (_orientation)
            {
                case 'N':
                    _orientation = 'W';
                    break;
                case 'E':
                    _orientation = 'N';
                    break;
                case 'S':
                    _orientation = 'E';
                    break;
                case 'W':
                    _orientation = 'S';
                    break;
            }
        }
    }
}