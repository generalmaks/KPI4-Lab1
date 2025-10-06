namespace KPI4Lab1;

public class GameOfLifeDisplay
{
    private GameOfLife _gameOfLife;
    private readonly int _characterWidth;

    public GameOfLifeDisplay(GameOfLife gameOfLife,  int characterWidth=2)
    {
        _gameOfLife = gameOfLife;
        _characterWidth = characterWidth;
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
                for(var i = 0; i < _characterWidth; i++)
                {
                    Console.Write(_gameOfLife.Grid[row, col] ? "█" : "  ");
                }
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
}