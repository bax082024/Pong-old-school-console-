namespace PongGame.Models
{
  public class Ball
  {
    public int X { get; set; }
    public int Y { get; set; }
    public int XDirection { get; set; }
    public int YDirection { get; set; }

    public Ball(int startX, int startY)
    {
      X = startX;
      Y = startY;
      XDirection = 1;
      XDirection = 1;
    }

    public void BounceHorizontal() => XDirection *= -1;
    public void BounceVertical() => YDirection *= -1;


  }

}