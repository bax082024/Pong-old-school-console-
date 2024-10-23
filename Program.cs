using PongGame.Services;

namespace PongGame
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.CursorVisible = false;
      var GameService = new GameService();
      GameService.Start();
    }

  }

}