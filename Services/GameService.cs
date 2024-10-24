using System;
using PongGame.Models;

namespace PongGame.Services
{
  public class GameService
  {
    private const int ScreenWidth = 40;
    private const int ScreenHeight = 20;
    private Paddle leftPaddle;
    private Paddle rightPaddle;
    private Ball ball;
    private Random random;
    private int delay = 200;
    private int leftScore = 0;
    private int rightScore = 0;

    public GameService()
    {
      leftPaddle = new Paddle(ScreenHeight / 2, ScreenHeight);
      rightPaddle = new Paddle(ScreenHeight / 2, ScreenHeight);
      ball = new Ball(ScreenWidth / 2, ScreenHeight / 2);
      random = new Random();
    }

    public void Start()
    {
      // console window and buffer size .
      if (Console.LargestWindowWidth >= ScreenWidth && Console.LargestWindowHeight >= ScreenHeight + 2)
      {
        // only for windows. Disable for mac etc...
        Console.SetWindowSize(ScreenWidth, ScreenHeight + 2);
        Console.SetBufferSize(ScreenWidth, ScreenHeight + 2);
      }
      else
      {
        Console.WriteLine("Screen too small for the game!");
        return;
      }

      while (true)
      {
        HandleInput();
        MoveBall();
        Draw();
        System.Threading.Thread.Sleep(delay);

        if (delay > 50)
        {
          delay -= 1; // Speed up the game over time
        }
      }
    }

    private void HandleInput()
    {
      if (Console.KeyAvailable)
      {
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
          case ConsoleKey.W:
            leftPaddle.MoveUp();
            break;

          case ConsoleKey.S:
            leftPaddle.MoveDown();
            break;

          case ConsoleKey.UpArrow:
            rightPaddle.MoveUp();
            break;

          case ConsoleKey.DownArrow:
            rightPaddle.MoveDown();
            break;
        }
      }
    }

    private void MoveBall()
    {
      int prevX = ball.X;
      int prevY = ball.Y;

      ball.Move();

      ClearBallPosition(prevX, prevY);

      if (ball.Y <= 0 || ball.Y >= ScreenHeight - 1)
      {
        ball.BounceVertical();
      }

      if (ball.X <= 1 && ball.Y == leftPaddle.Position || ball.X >= ScreenWidth - 2 && ball.Y == rightPaddle.Position)
      {
        ball.BounceHorizontal();
      }

      if (ball.X <= 0 || ball.X >= ScreenWidth - 1)
      {
        Console.Clear();
        Console.WriteLine(ball.X <= 0 ? "Right Player Wins!!!" : "Left Player Wins!!!");
        Environment.Exit(0);
      }
    }

    private void ClearBallPosition(int prevX, int prevY)
    {
      if (prevX >= 0 && prevX < ScreenWidth && prevY >= 0 && prevY < ScreenHeight)
      {
        Console.SetCursorPosition(prevX, prevY);
        Console.Write(" ");
      }
    }

    private void ResetBall()
    {
      ball = new Ball(ScreenWidth / 2, ScreenHeight / 2);
      delay = 200;
    }

    private void Draw()
    {
      // Clear console before next frame
      Console.Clear();

      // Draw paddles
      Console.SetCursorPosition(1, leftPaddle.Position);
      Console.Write("|");

      Console.SetCursorPosition(ScreenWidth - 2, rightPaddle.Position);
      Console.Write("|");

      // Draw ball
      if (ball.X >= 0 && ball.X < ScreenWidth && ball.Y >= 0 && ball.Y < ScreenHeight)
      {
        Console.SetCursorPosition(ball.X, ball.Y);
        Console.Write("0");
      }

    }
  }
}
