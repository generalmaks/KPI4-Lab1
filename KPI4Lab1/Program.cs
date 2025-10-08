namespace KPI4Lab1;

class Program
{
    static void Main(string[] args)
    {
        var inputData = FileParser.Parse(args[0]);

        var grid = inputData.grid;
        var generations = inputData.generations;
        
        const int charWidth = 1;
        const char emptyCellChar = '.';
        const char fullCellChar = 'x';
        var gameOfLife = new GameOfLife(grid);
        
        var game = new GameOfLifeDisplay(
            gameOfLife,
            charWidth, 
            emptyCellChar,
            fullCellChar
            );

        for (int i = 0; i < 10; i++)
        {
            game.Step();
            Thread.Sleep(500);
        }
    }
}
