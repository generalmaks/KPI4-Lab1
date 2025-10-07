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
            { false, false, false, false, false },
            { false, true, true, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false }
        };
        _gameOfLife = new GameOfLife(_rows, _columns, initState);
        _gameOfLife.Step();
        Assert.That(_gameOfLife.Grid, Is.EqualTo(secondState));
    }
}