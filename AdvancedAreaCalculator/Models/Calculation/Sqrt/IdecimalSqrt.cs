namespace AreaCalculator.Models;

public interface IDecimalSqrt
{
    /// <summary>
    ///  Sqrt Interface for decimal numbers
    /// </summary>
    /// <param name="first">Number to calculate</param>
    /// <param name="epsilon">The error in estimate</param>
    /// <returns></returns>
    public  decimal Sqrt(decimal first, decimal epsilon = default);
}