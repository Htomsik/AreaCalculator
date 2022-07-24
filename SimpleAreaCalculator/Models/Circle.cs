namespace SimpleAreaCalculator.Models;

public sealed class Circle : BaseFigure
{
    #region Constructors

    /// <summary>
    ///     Circle
    /// </summary>
    /// <param name="radius">Circle radius</param>
    public Circle(double radius)
    {
        Radius = radius;
        CheckException();
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Circle radius
    /// </summary>
    public dynamic Radius { get; }

    #endregion

    #region Methods

    /// <summary>
    ///     Calculate circle area
    /// </summary>
    protected override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>
    ///     Check circle exception
    /// </summary>
    /// <exception cref="ArgumentNullException">If Radius less than 0</exception>
    protected override void CheckException()
    {
        if (Radius! < 0) throw new ArgumentNullException("Radius can't be less than 0");
    }

    #endregion
}