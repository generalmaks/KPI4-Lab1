namespace KPI4Lab1;

public static class FileParser
{
    public static (int generations, bool[,] grid) ParseFile(string path)
    {
        var fileInput = File.ReadAllLines(path);
        return Parse(fileInput);
        
    }

    public static (int generations, bool[,] grid) Parse(string[] input)
    {
        input = input.Select(line => line.Trim()).Where(line => line.Length > 0).ToArray();
        
        if (input.Length < 3)
            throw new ArgumentException("Input file must contain at least three lines (generations, size, and initial grid)");

        int generations = int.Parse(input[0]);

        var size = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);
        
        if (generations <= 0 || rows <= 0 || cols <= 0)
            throw new ArgumentException("Generations must be positive and more than zero");

        int factualRows = input.Length - 2;
        int factualCols = input[2].Length;
        
        if (rows != factualRows || cols != factualCols)
            throw new ArgumentException("Grid must have the same amount of rows and columns as specified.\n" +
                                        $"{rows},{cols} size specified, but actual size is {factualRows},{factualCols}");

        var grid = new bool[rows, cols];
        for (int r = 0; r < rows; r++)
        {
            var line = input[2 + r];
            for (int c = 0; c < cols; c++)
            {
                grid[r, c] = line[c] == 'x';
            }
        }

        return (generations, grid);
    }
}