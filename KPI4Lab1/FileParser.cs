namespace KPI4Lab1;

public static class FileParser
{
    public static (int generations, bool[,] grid) Parse(string path)
    {
        var fileInput = File.ReadAllLines(path);

        if (fileInput.Length < 3)
            throw new ArgumentException("Input file must contain at least three lines (generations, size, and initial grid)");

        int generations = int.Parse(fileInput[0]);

        var size = fileInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);

        var grid = new bool[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            var line = fileInput[2 + r];
            for (int c = 0; c < cols; c++)
            {
                grid[r, c] = line[c] == 'x';
            }
        }

        if (grid.Length != rows * cols)
            throw new ArgumentException("Grid must have the same amount of rows and columns as specified.");

        return (generations, grid);
    }
}