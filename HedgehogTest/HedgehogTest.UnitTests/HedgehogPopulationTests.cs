using FluentAssertions;
using HedgehogTest.Core;

namespace HedgehogTest.UnitTests;

public class HedgehogPopulationTests
{
    /*  target: red     
     *  1 |r g b|r g b| 19*r     
     *  2 |r g b|  g b|   
     *  3 |r g b|  g b|   
     *  4 |  g b|  g b|  
     *  5 |  g b|  g b|  
     *  6 |    b|  g b| 
     *  7 |    b|  g b|
     *  8 |    b|  g b|
     *  9 |    b|  g b|
     *  10|    b|     |
     *  11|    b|     |
     */ 
    [Fact]
    public void CalculateNumberOfStepsToGetSimilar_True_1()
    {
        int numberOfSteps = HedgehogPopulation.CalculateNumberOfStepsToGetSimilar(0, [3, 5, 11]);
        numberOfSteps.Should().Be(11);
    }
    
    /*  target: blue
     *  1|r g b| 8*b
     *  2|r g b|
     *  3|r g  |
     *  4|     |
     */
    [Fact]
    public void CalculateNumberOfStepsToGetSimilar_True_2()
    {
        int numberOfSteps = HedgehogPopulation.CalculateNumberOfStepsToGetSimilar(2, [3, 3, 2]);
        numberOfSteps.Should().Be(3);
    }

    [Theory]
    [InlineData(2, new int[]{4, 5, 1})]
    [InlineData(2, new int[]{0, 0, 1})]
    [InlineData(1, new int[]{0, 0, 0})]
    [InlineData(0, new int[]{5, 5, 7})]
    [InlineData(1, new int[]{1, 1, 9})]
    void CalculateNumberOfStepsToGetSimilar_False_1(int color, int[] families)
    {
        int numberOfSteps = HedgehogPopulation.CalculateNumberOfStepsToGetSimilar(color, families);
        numberOfSteps.Should().Be(-1);
    }
}