using KPI4Lab1;

namespace KPI4Lab1Tests;

public class FileParserTest
{
    [Test]
    public void Parse_CorrectInput_CorrectOutput()
    {
        const string input = """
                             3
                             3 3
                             .x.
                             xxx
                             xx.
                             """;
        var expectedGrid = new bool[,]
        {
            { false, true, false },
            { true, true, true },
            { true, true, false }
        };
        
        var (generations, grid) = FileParser.Parse(input.Split('\n'));
        Assert.Multiple(() =>
        {
            Assert.That(generations, Is.EqualTo(3));
            Assert.That(grid, Is.EqualTo(expectedGrid));
        });
    }

    [Test]
    public void Parse_IncorrectSizeInput_ThrowsException()
    {
        const string input = """
                             3
                             2 5
                             .x.
                             xxx
                             xx.
                             """;
        Assert.That(() => FileParser.Parse(input.Split('\n')),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Parse_DifferentRowSizes_ThrowsException()
    {
        const string input = """
                             3
                             3 3
                             .x..
                             xxx
                             xx.
                             """;
        Assert.That(() => FileParser.Parse(input.Split('\n')),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Parse_ZeroOrNegativeValues_ThrowsException()
    {
        const string input = """
                             -3
                             3 3
                             .x.
                             xxx
                             xx.
                             """;
        Assert.That(() => FileParser.Parse(input.Split('\n')),
            Throws.TypeOf<ArgumentException>());
    }
}