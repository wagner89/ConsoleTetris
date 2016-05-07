namespace ConsoleTetris.GameLogic
{
    public class BouncingBall
    {
        public int PreviousX = 1;
        public int PreviousY = 1;

        private readonly int _screenHeight;
        private readonly int _screenWidth;

        private int _x = 1;
        private int _xDirection = 1;

        private int _y = 1;
        private int _yDirection = 1;

        public BouncingBall(int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public int X
        {
            get { return _x; }
            set
            {
                PreviousX = _x;
                _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                PreviousY = _y;
                _y = value;
            }
        }

        public void MoveToNextPosition()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            switch (_xDirection)
            {
                case 1:
                    {
                        if (X + 2 >= _screenWidth)
                        {
                            _xDirection *= -1;
                        }
                        X += _xDirection;
                        break;
                    }
                case -1:
                    {
                        if (X - 2 < 0)
                        {
                            _xDirection *= -1;
                        }
                        X += _xDirection;
                        break;
                    }
            }

            switch (_yDirection)
            {
                case 1:
                    {
                        if (Y + 2 >= _screenHeight)
                        {
                            _yDirection *= -1;
                        }
                        Y += _yDirection;
                        break;
                    }
                case -1:
                    {
                        if (Y - 2 < 0)
                        {
                            _yDirection *= -1;
                        }
                        Y += _yDirection;
                        break;
                    }
            }
        }
    }
}