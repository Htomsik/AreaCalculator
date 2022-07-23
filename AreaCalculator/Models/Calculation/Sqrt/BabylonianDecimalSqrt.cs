namespace AreaCalculator.Models;

public class BabylonianDecimalSqrt:IDecimalSqrt 
{
    /// <summary>
    /// Babylonian Sqrt Method for decimal numbers
    /// </summary>
    /// <param name="first">Number to calculate</param>
    /// <param name="epsilon">The error in estimate</param>
    /// <returns></returns>
    public decimal Sqrt(decimal first, decimal epsilon = 0)
    {
        decimal ourGuess = epsilon == 0 ? first / 2m : epsilon;
        decimal result = first / ourGuess;
        decimal average = (ourGuess + result) / 2m;

        if (average == ourGuess) 
            return average;
        else
            return Sqrt(first, average);
    }
    
}

