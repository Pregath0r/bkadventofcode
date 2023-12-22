namespace D2;

public class MinimumGameCubeCalculator
{
    public static MinimumGameCubes CalculateMinimumGameCubes(Game game)
    {
        var minimumGameCubes = new MinimumGameCubes();
        foreach (var set in game.Sets)
        {
            if (set.RedCubes > minimumGameCubes.RedCubes)
            {
                minimumGameCubes.RedCubes = set.RedCubes;
            }
            
            if (set.BlueCubes > minimumGameCubes.BlueCubes)
            {
                minimumGameCubes.BlueCubes = set.BlueCubes;
            }
            
            if (set.GreenCubes > minimumGameCubes.GreenCubes)
            {
                minimumGameCubes.GreenCubes = set.GreenCubes;
            }
        }

        return minimumGameCubes;
    }
    
    
    
}