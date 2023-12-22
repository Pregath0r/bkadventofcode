namespace D2;

public class GameParser
{
    public Game ParseGame(string input)
    {
        var game = new Game();
        var gameName = ParseName(input);
        game.Name = gameName;
        
        var gameId = ParseGameId(input);
        game.GameId = gameId;

        var sets = ParseSets(input);
        game.Sets = sets;
        
        return game;
    }

    private string ParseName(string input)
    {
        var gameSection = input.Split(":")[0];
        return gameSection;
    }
    
    private int ParseGameId(string input)
    {
        var gameSection = input.Split(":")[0];
        var gameId = new string(gameSection.SkipWhile(c => !char.IsDigit(c))
            .TakeWhile(char.IsDigit)
            .ToArray());
        return int.Parse(gameId);
    }

    private List<Set> ParseSets(string input)
    {
        var setSection = GetGameWithoutName(input);
        var setTexts = setSection.Split(";");

        var sets = new List<Set>();
        foreach (var setText in setTexts)
        {
            var set = CreateSet(setText);
            sets.Add(set);
        }

        return sets;
    }

    private Set CreateSet(string setText)
    {
        var redCubes = GetRedCubes(setText);
        var blueCubes = GetBlueCubes(setText);
        var greenCubes = GetGreenCubes(setText);


        return new Set()
        {
            RedCubes = redCubes,
            GreenCubes = greenCubes,
            BlueCubes = blueCubes
        };
    }

    private int GetGreenCubes(string setText)
    {
        return GetCubes(setText, "green");
    }

    private int GetBlueCubes(string setText)
    {
        return GetCubes(setText, "blue");
    }

    private int GetRedCubes(string setText)
    {
        return GetCubes(setText, "red");
    }
    
    private int GetCubes(string setText, string color)
    {
        var cubesSections = setText.Split(",");
        return (from cubesSection in cubesSections
            where cubesSection.Contains(color, StringComparison.InvariantCultureIgnoreCase)
            select new string(cubesSection.SkipWhile(c => !char.IsDigit(c))
                .TakeWhile(char.IsDigit)
                .ToArray())
            into cubeCount
            select int.Parse(cubeCount)).FirstOrDefault();
    }

    private string GetGameWithoutName(string input)
    {
        var gameSection = input.Split(":")[1];
        return gameSection;
    }
}