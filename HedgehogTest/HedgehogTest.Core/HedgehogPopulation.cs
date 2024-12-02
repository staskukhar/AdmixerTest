using HedgehogTest.Core.Exceptions;
using HedgehogTest.Core.Models;

namespace HedgehogTest.Core;

public class HedgehogPopulation
{
    private static readonly int[] ColorsIndexes = [0, 1, 2];
    
    public static int CalculateNumberOfStepsToGetSimilar(int color, int[] families)
    {
        ValidateColorIndex(color);
        ValidatePopulationArray(families);
        
        Population population = MapToPopulation(color, families);
        bool isTargetReachable = IsTargetReachable(population);

        if (!isTargetReachable)
        {
            return -1;
        }

        if (population.SmallerFamily == population.BiggerFamily)
        {
            return population.SmallerFamily;
        }
        
        int numberOfStepsToMakeTemporaryFamiliesEqual = (population.BiggerFamily - population.SmallerFamily) / 3;
        int numberOfHedgehogsInEqualFamily = population.BiggerFamily - numberOfStepsToMakeTemporaryFamiliesEqual;
        
        return numberOfStepsToMakeTemporaryFamiliesEqual + numberOfHedgehogsInEqualFamily;
    }

    public static void ValidateColorIndex(int color)
    {
        if (!ColorsIndexes.Contains(color))
        {
            throw new InvalidColorIndexException(color);
        }
    }

    public static void ValidatePopulationArray(int[] families)
    {
        if (ColorsIndexes.Length != families.Length)
        {
            throw new ArrayTypeMismatchException("The only possible number of hedgehog colors is 3.");
        }
    }

    public static Population MapToPopulation(int color, int[] families)
    {
        IList<int> temporaryFamilies = [];
        for (int i = 0; i < families.Length; i++)
        {
            if (i != color)
            {
                temporaryFamilies.Add(families[i]);
            }
        }
        return new Population(families[color], temporaryFamilies.Min(), temporaryFamilies.Max());
    }

    public static bool IsTargetReachable(Population population)
    {
        int gap = population.BiggerFamily - population.SmallerFamily;
        
        if (population.SmallerFamily == 0 || population.SmallerFamily == 0)
        {
            return false;
        }
        
        if (gap > 0 && gap < 3)
        {
            return false;
        }

        if (gap % 3 != 0)
        {
            return false;   
        }

        if (gap / 3 > population.Target)
        {
            return false;
        }
        
        return true;
    }
}