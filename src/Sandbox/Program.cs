using ConsoleTetris.GameClock;
using ConsoleTetris.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using static ConsoleTetris.ScreenUtilities.ConsoleManager;

namespace ConsoleTetris
{
    internal class Program
    {
        private static void Main()
        {
            IDisposable gameCycleSubscription = null;

            try
            {
                HideCursor();
                SetConsoleToFullScreen();
                DrawBoder();

                var bouncingBalls = BouncingBall.SetupBouncingBalls(10);

                gameCycleSubscription = GameCycle.GameCycleObservable.Subscribe(_ => UpdateGameState(bouncingBalls));

                Console.ReadKey();
            }
            finally
            {
                gameCycleSubscription?.Dispose();
            }
        }

        private static void UpdateGameState(List<BouncingBall> balls)
        {
            balls.ForEach(ball => ball.MoveToNextPosition());
            DrawGameState(balls);
        }

        private static void DrawGameState(IEnumerable<BouncingBall> balls)
        {
            foreach (var ball in balls)
            {
                DrawToBuffer(ball.PreviousX, ball.PreviousY, ' ');
                DrawToBuffer(ball.X, ball.Y, 'o');
            }

            BlitBufferToScreen();
        }
    }
}