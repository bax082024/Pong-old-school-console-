namespace PongGame.Models
{
  public class Paddle
  {
    // Paddle posiion
    public int Position { get; private set; }
    private readonly int screenHeight;
    
    public Paddle(int startPosition, int screenHeight)
    {
        Position = startPosition;
        this.screenHeight = screenHeight;
    }

    // Move up
    public void MoveUp()
    {
        if (Position > 1)
            Position--;
    }

    // Move Down
    public void MoveDown()
    {
        if (Position < screenHeight - 2)
            Position++;
    }
  }
}