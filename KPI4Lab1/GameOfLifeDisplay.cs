namespace KPI4Lab1;

public class GameOfLifeDisplay
{
    private readonly GameOfLife _gameOfLife;
    private readonly int _characterWidth;
    private readonly char _emptyCellChar;
    private readonly char _fullCellChar;

    public GameOfLifeDisplay(
        GameOfLife gameOfLife,  
        int characterWidth=1, 
        char emptyCellChar=' ', 
        char fullCellChar='█'
        )
    {
        _gameOfLife = gameOfLife;
        _characterWidth = characterWidth;
        _emptyCellChar = emptyCellChar;
        _fullCellChar = fullCellChar;
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
                    Console.Write(_gameOfLife.Grid[row, col] ? _fullCellChar : _emptyCellChar);
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

    public void Steps(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            _gameOfLife.Step();
        }
        Display();
    }
}