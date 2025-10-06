namespace KPI4Lab1;

class Program
{
    static void Main(string[] args)
    {
        var game = new GameOfLifeDisplay(new GameOfLife(10, 10), 2);
        game.Randomize();

        for (int i = 0; i < 10; i++)
        {
            game.Step();
            Thread.Sleep(1000);
        }
    }
}
