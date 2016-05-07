using ConsoleTetris.GameClock;
using ConsoleTetris.GameLogic;
using System;
using static ConsoleTetris.ScreenUtilities.ConsoleManager;

namespace ConsoleTetris
{
    internal class Program
    {
        private static void Main()
        {
            BouncingBall bouncingBall;
            IDisposable gameCycleSubscription = null;

            try
            {
                HideCursor();
                SetConsoleToFullScreen();
                DrawBoder();

                bouncingBall = new BouncingBall(Console.WindowWidth, Console.WindowHeight);

                gameCycleSubscription = GameCycle.GameCycleObservable.Subscribe(_ => UpdateGameState(bouncingBall));

                Console.ReadKey();
            }
            finally
            {
                gameCycleSubscription?.Dispose();
            }
        }

        private static void UpdateGameState(BouncingBall ball)
        {
            ball.MoveToNextPosition();
            DrawGameState(ball);
        }

        private static void DrawGameState(BouncingBall ball)
        {
            DrawToBuffer(ball.PreviousX, ball.PreviousY, ' ');
            DrawToBuffer(ball.X, ball.Y, '@');
            BlitBufferToScreen();
        }
    }
}