namespace SimpleAreaCalculator.Models;

public abstract class BaseFigure : IFigure
{
    #region Constructors

    protected BaseFigure()
    {
        _area = new Lazy<double>(CalculateArea);
    }

    #endregion

    #region Fields

    private Lazy<double> _area { get; }

    #endregion

    #region Properties

    /// <summary>
    ///     Figure area
    /// </summary>
    public double Area => _area.Value;

    #endregion

    #region Methods

    /// <summary>
    ///     Calculate figure area
    /// </summary>
    protected abstract double CalculateArea();

    /// <summary>
    ///     Check excepition
    /// </summary>
    protected abstract void CheckException();

    #endregion
}