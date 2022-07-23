namespace AreaCalculator.Models.Base;

public abstract class BaseFigure : IFigure
{

    #region Fields
    private Lazy<dynamic> _area { get; }

    #endregion
    
    #region Properties

    /// <summary>
    ///     Figure area
    /// </summary>
    public dynamic Area => _area.Value;

    #endregion
    
    protected BaseFigure()
    {
        _area = new Lazy<dynamic>(CalculateArea);
    }
    
    #region Methods

    /// <summary>
    ///     Calculate figure area
    /// </summary>
    protected abstract dynamic CalculateArea();

    /// <summary>
    ///     Check excepition
    /// </summary>
    protected abstract void CheckException();

    #endregion
}