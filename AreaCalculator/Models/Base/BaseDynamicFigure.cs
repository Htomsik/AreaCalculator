namespace AreaCalculator.Models.Base;

public abstract class BaseDynamicFigure<T>:IDynamicFigure<T>
{
    
    #region Fields

    private Lazy<dynamic> _area;

    #endregion
    
    #region Properties

    /// <summary>
    ///     Figure area
    /// </summary>
    public dynamic Area => _area.Value;

    #endregion
    
    #region Methods

    /// <summary>
    ///     Calculate figure area
    /// </summary>
    protected abstract dynamic CalculateArea();

    /// <summary>
    ///     Check excepition
    /// </summary>
    protected abstract void CheckException();


    protected BaseDynamicFigure()
    {
        AreaChanged();
    }

    
    public Action? OnFigureChanged { get; set; }

    public abstract void ChangeParameter(T newParams);

    protected void AreaChanged()
    {
        _area = new Lazy<dynamic>(CalculateArea);
        OnFigureChanged?.Invoke();
    }

    #endregion
}