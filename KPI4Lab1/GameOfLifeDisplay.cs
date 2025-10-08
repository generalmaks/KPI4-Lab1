namespace KPI4Lab1;

public class GameOfLifeDisplay
{
    private readonly GameOfLife _gameOfLife;
    private const char FullCellChar = 'x';
    private const char EmptyCellChar = '.';

    public GameOfLifeDisplay(GameOfLife gameOfLife)
    {
        _gameOfLife = gameOfLife;
    }

    public void Display()
    {
        var rows = _gameOfLife.Rows;
        var cols = _gameOfLife.Columns;
        
        for (var col = 0; col < rows; col++)
            Console.Write("==");
        Console.WriteLine();

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                Console.Write(_gameOfLife.Grid[row, col] ? FullCellChar : EmptyCellChar);
            }
            Console.WriteLine();
        }
    }

    public void Step()
    {
        _gameOfLife.Step();
        Display();
    }

    public void Randomize()
    {
        _gameOfLife.Randomize();
        Display();
    }

    public void Steps(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            _gameOfLife.Step();
        }
        Display();
    }
}