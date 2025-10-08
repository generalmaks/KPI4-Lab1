namespace KPI4Lab1;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0) throw new ArgumentException("No arguments provided");
        var inputData = FileParser.ParseFile(args[0]);

        var grid = inputData.grid;
        var generations = inputData.generations;
        
        var gameOfLife = new GameOfLife(grid);
        
        var game = new GameOfLifeDisplay(gameOfLife);

        game.Steps(generations);
    }
}
