namespace D2;

public class GameValidator
{
    public static bool IsValid(Game game, Bag bag)
    {
        var sets = game.Sets;
        foreach (var set in sets)
        {
            if (set.RedCubes > bag.RedCubes)
            {
                return false;
            }
            
            if (set.BlueCubes > bag.BlueCubes)
            {
                return false;
            }
            
            if (set.GreenCubes > bag.GreenCubes)
            {
                return false;
            }
        }

        return true;
    }
}