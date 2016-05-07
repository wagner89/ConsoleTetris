using System;
using System.Collections.Generic;

namespace ConsoleTetris.GameLogic
{
    public class BouncingBall
    {
        public int PreviousX = 1;
        public int PreviousY = 1;

        private readonly int _screenHeight;
        private readonly int _screenWidth;

        public BouncingBall(int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public int X { get; set; } = 1;

        public int Y { get; set; } = 1;

        public int XDirection { get; set; } = 1;

        public int YDirection { get; set; } = 1;

        public int Speed { get; set; } = 1;

        public void MoveToNextPosition()
        {
            PreviousX = X;
            PreviousY = Y;

            for (var i = 0; i < Speed; i++) MoveOnePosition();
        }

        private void MoveOnePosition()
        {
            switch (XDirection)
            {
                case 1:
                    if (X + 2 >= _screenWidth) XDirection *= -1;
                    break;

                case -1:
                    if (X - 2 < 0) XDirection *= -1;
                    break;
            }

            switch (YDirection)
            {
                case 1:
                    if (Y + 2 >= _screenHeight) YDirection *= -1;
                    break;

                case -1:
                    if (Y - 2 < 0)
                        YDirection *= -1;
                    break;
            }

            X += XDirection;
            Y += YDirection;
        }

        public static List<BouncingBall> SetupBouncingBalls(int numberOfBalls)
        {
            var bouncingBalls = new List<BouncingBall>();
            var rng = new Random();

            for (var i = 0; i < numberOfBalls; i++)
                bouncingBalls.Add(new BouncingBall(Console.WindowWidth, Console.WindowHeight));

            foreach (var ball in bouncingBalls)
            {
                ball.X = 2 + rng.Next(Console.WindowWidth - 4);
                ball.Y = 2 + rng.Next(Console.WindowHeight - 4);

                ball.XDirection = rng.Next() % 2 == 0 ? 1 : -1;
                ball.YDirection = rng.Next() % 2 == 0 ? 1 : -1;

                ball.Speed = 1 + rng.Next(4);
            }

            return bouncingBalls;
        }
    }
}