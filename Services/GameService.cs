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
  }

  public GameService()
  {
    leftPaddle = new Paddle(ScreenHeight / 2, ScreenHeight);
    rightPaddle = new Paddle(ScreenHeight / 2, ScreenHeight);
    ball = new Ball(ScreenWidth / 2, ScreenHeight / 2);
    random = new Random();
  }

}