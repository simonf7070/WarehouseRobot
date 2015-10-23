namespace WarehouseRobot
{
    public class Robot
    {
        private readonly IWarehouse _warehouse;
        private int _x;
        private int _y;
        private char _orientation;

        public Robot(IWarehouse warehouse, int startX, int startY, char startOrientation)
        {
            _warehouse = warehouse;
            _x = startX;
            _y = startY;
            _orientation = startOrientation;
        }

        public string Position 
        {
            get { return string.Format("{0} {1} {2}", _x, _y, _orientation); }
        }

        private void TurnLeft()
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

        private void TurnRight()
        {
            switch (_orientation)
            {
                case 'N':
                    _orientation = 'E';
                    break;
                case 'E':
                    _orientation = 'S';
                    break;
                case 'S':
                    _orientation = 'W';
                    break;
                case 'W':
                    _orientation = 'N';
                    break;
            }
        }

        private void MoveForward()
        {
            var newPositionX = _x;
            var newPositionY = _y;
            
            switch (_orientation)
            {
                case 'N':
                    newPositionY = _y + 1;
                    break;
                case 'E':
                    newPositionX = _x + 1;
                    break;
                case 'S':
                    newPositionY = _y - 1;
                    break;
                case 'W':
                    newPositionX = _x - 1;
                    break;
            }

            if (_warehouse.IsValidCoordinate(newPositionX, newPositionY))
            {
                _x = newPositionX;
                _y = newPositionY;
            }
        }

        public void ProcessCommands(string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case '^':
                        MoveForward();
                        break;
                    case '<':
                        TurnLeft();
                        break;
                    case '>':
                        TurnRight();
                        break;
                }
            }
        }
    }
}