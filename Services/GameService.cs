using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
      Console.SetWindowSize(ScreenWidth, ScreenHeight + 2);
      Console.SetBufferSize(ScreenWidth, ScreenHeight + 2);

      while (true)
      {
        HandleInput();
        MoveBall();
        Draw();
        System.Threading.Thread.Sleep(delay);

        if (delay > 50)
        {
          delay -= 1;
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
      ball.Move();

      if (ball.Y <= 0 || ball.Y >= ScreenHeight - 1)
      {
        ball.BounceVertical();
      }

      if (ball.X <= 1 && ball.Y == leftPaddle.Position || ball.X >= ScreenWidth - 2 && ball.Y == rightPaddle.Position)
      {
        ball.BounceHorizontal();
      }

      if (ball.X <= 0)
      {
        rightScore ++;
        Console.Clear();
        Console.WriteLine("Right Player Wins!!!");
        System.Threading.Thread.Sleep(1000);
        ResetBall();
      }
      else if (ball.X >= ScreenWidth - 1)
      {
        leftScore++;
        Console.Clear();
        Console.WriteLine("Left Player Wins!!!");
        System.Threading.Thread.Sleep(1000);
        ResetBall();
      }
    }
    private void ResetBall()
    {
      ball.X = ScreenWidth / 2;
      ball.Y = ScreenHeight / 2;
      delay = 200;

    }

    }

    private void Draw()
    {
      
      Console.SetCursorPosition(0, 0);
    Console.WriteLine(new string('-', ScreenWidth));

    // Draw bottom wall
    Console.SetCursorPosition(0, ScreenHeight);
    Console.WriteLine(new string('-', ScreenWidth));

    // Draw left paddle
    Console.SetCursorPosition(1, leftPaddle.Position);
    Console.Write("|");

    // Draw right paddle
    Console.SetCursorPosition(ScreenWidth - 2, rightPaddle.Position);
    Console.Write("|");

    // Draw ball
    Console.SetCursorPosition(ball.X, ball.Y);
    Console.Write("O");

    // Draw score if needed or other UI elements
    Console.SetCursorPosition(0, ScreenHeight + 1); // Position score below the game field
    Console.WriteLine($"Score: {leftScore} - {rightScore}");

      
      


    }
  }
}