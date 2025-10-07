using KPI4Lab1;

namespace KPI4Lab1Tests;

public class Tests
{
    private GameOfLife _gameOfLife;
    private int _rows;
    private int _columns;
    [SetUp]
    public void Setup()
    {
        _gameOfLife = new GameOfLife(_rows, _columns);
        _rows = 5;
        _columns = 5;
    }

    [Test]
    public void Step()
    {
        var initState = new bool[,]
        {
            { false, true, false, false, false },
            { true, false, true, false, false },
            { false, false, false, true, false },
            { false, false, false, false, false },
            { false, false, false, false, false }
        };
        var secondState = new bool[,]
        {
            { false, true, false, false, false },
            { false, true, true, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false }
        };
        _gameOfLife = new GameOfLife(initState);
        _gameOfLife.Step();
        Assert.That(_gameOfLife.Grid, Is.EqualTo(secondState));
    }
    
    [Test]
    public void Step_ZeroGrid_ReturnsZeroGrid()
    {
        var initState = new bool[,]
            { };
        _gameOfLife = new GameOfLife(initState);

        _gameOfLife.Step();
        Assert.That(_gameOfLife.Grid, Is.EqualTo(initState));
    }

    [Test]
    public void Step_InputTub_ReturnsTub()
    {
        var initState = new bool[,]
        {
            { false, true, false },
            { true, false, true },
            { false, true, false },
        };
        _gameOfLife = new GameOfLife(initState);
        _gameOfLife.Step();
        Assert.That(_gameOfLife.Grid, Is.EqualTo(initState));
    }

    [Test]
    public void Step_InputBeehive()
    {
        var initState = new bool[,]
        {
            { false, true, true, false },
            { true, false, false, true },
            { false, true, true, false },
        };
        _gameOfLife = new GameOfLife(initState);
        _gameOfLife.Step();
        Assert.That(_gameOfLife.Grid, Is.EqualTo(initState));
    }
}