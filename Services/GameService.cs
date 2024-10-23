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
  

    public GameService()
    {
      leftPaddle = new Paddle(ScreenHeight / 2, ScreenHeight);
      rightPaddle = new Paddle(ScreenHeight / 2, ScreenHeight);
      ball = new Ball(ScreenWidth / 2, ScreenHeight / 2);
      random = new Random();
    }

    public void Start()
    {
      while (true)
      {
        HandleInput();
        MoveAll();
        Draw();
        System.Threading.Thread.Sleep(100);
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

      if (ball.X <= 0 || ball.X >= ScreenWidth - 1)
      {
        Console.Clear();
        Console.WriteLine(ball.X <= 0 ? "Right Player Wins!!!" : "Left Player Wins!!!");
        Environment.Exit(0);
      }
    }

    private void Draw()
    {
      
    }
  }
}