namespace KPI4Lab1;

public class GameOfLife
{
    public readonly int Rows;
    public readonly int Columns;
    public readonly int StepTime;
    public bool[,] Grid { get; set; }
    
    public GameOfLife(int rows, int columns, bool[,]? initialState = null)
    {
        this.Rows = rows;
        this.Columns = columns;
        this.Grid = initialState ?? new bool[rows, columns];
    }

    public void Step()
    {
        var next = new  bool[Rows, Columns];

        for (var row = 0; row < Rows; row++)
        {
            for (var col = 0; col < Columns; col++)
            {
                var neighbors = CountNeighbours(row, col);

                if (Grid[row, col])
                    next[row, col] = neighbors is 2 or 3;
                else
                    next[row, col] = (neighbors == 3);
            }
        }
        
        Grid = next;
    }

    private int CountNeighbours(int row, int col)
    {
        var count = 0;
        for (var offsetW = -1; offsetW <= 1; offsetW++)
        {
            for (var offsetH = -1; offsetH <= 1; offsetH++)
            {
                if (offsetW == 0 && offsetH == 0) continue;
                
                var posX = row + offsetW;
                var posY = col + offsetH;

                if (posX >= 0 && posX < Rows && posY >= 0 && posY < Columns && Grid[posX, posY]) count++;
            }
        }
        return count;
    }

    public void Randomize(double cellChance = 0.5)
    {
        var rand = new Random();
        for (var row = 0; row < Rows; row++)
        {
            for (var col = 0; col < Columns; col++)
            {
                if(rand.NextDouble() <= cellChance)
                    Grid[row, col] = true;
                else
                    Grid[row, col] = false;
            }
        }
    }
}