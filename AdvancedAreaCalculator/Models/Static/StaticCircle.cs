using AreaCalculator.Models.Base;

namespace AreaCalculator.Models;

public sealed class StaticCircle : BaseFigure
{
    #region Properties

    /// <summary>
    ///     Circle radius
    /// </summary>
    public dynamic Radius { get; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Circle double
    /// </summary>
    /// <param name="radius">Circle double radius</param>
    public StaticCircle(double radius)
    {
        Radius = radius;
        CheckException();
    }

    /// <summary>
    ///     Circle decimal
    /// </summary>
    /// <param name="radius">Circle decimal radius</param>
    public StaticCircle(decimal radius)
    {
        Radius = radius;
        CheckException();
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Calculate circle area
    /// </summary>
    protected override dynamic CalculateArea()
    {
        return Radius is decimal ? GlobalConstants.DecimalPi * Radius * Radius : Math.PI * Radius * Radius;
    }

    /// <summary>
    ///     Check circle exception
    /// </summary>
    /// <exception cref="ArgumentNullException">If Radius less than 0</exception>
    protected sealed override void CheckException()
    {
        if (Radius! < 0) throw new ArgumentNullException("Radius can't be less than 0");
    }

    #endregion
}