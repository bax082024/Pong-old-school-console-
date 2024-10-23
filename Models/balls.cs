namespace PongGame.Models
{
  public class Ball
  {
    public int X { get; set; }
    public int Y { get; set; }
    public int XDirection { get; set; }
    public int YDirection { get; set; }

    // Ball Movement
    public Ball(int startX, int startY)
    {
      X = startX;
      Y = startY;
      XDirection = 1;
      YDirection = 1;
    }

    public void Move()
    {
      X += XDirection;
      Y += YDirection;
    }

    public void BounceHorizontal() => XDirection *= -1;
    public void BounceVertical() => YDirection *= -1;
  }
}