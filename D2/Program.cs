using System.Reflection;
using D2;
using Infrastructure;

var assembly = Assembly.GetExecutingAssembly();

var inputReader = new InputReader();
var input = inputReader.GetInput("D2.Input.input.txt", assembly);

var games = (from gameLine in input let gameParser = new GameParser() select gameParser.ParseGame(gameLine)).ToList();
var bag = new Bag()
{
    RedCubes = 12,
    GreenCubes = 13,
    BlueCubes = 14
};


var idSum = 0;
foreach (var game in games)
{
    Console.WriteLine(game.Name); Console.Write(" - "); Console.WriteLine("Sets: " + game.Sets.Count);
    var isGameValid = GameValidator.IsValid(game, bag);
    Console.WriteLine(" - Is valid: " + isGameValid);
    if (isGameValid)
    {
        idSum += game.GameId;
    }
}

Console.WriteLine("Id sum: " + idSum);


// PART 2
var gamePowers = games.Select(MinimumGameCubeCalculator.CalculateMinimumGameCubes).Select(minimumGameCubes => minimumGameCubes.RedCubes * minimumGameCubes.GreenCubes * minimumGameCubes.BlueCubes).ToList();
var gamePowerSum = gamePowers.Sum();
Console.WriteLine("Game power sum: " + gamePowerSum);

