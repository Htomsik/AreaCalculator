namespace AreaCalculator.Models.Base;

public interface IDynamicFigure<T>:IFigure
{
    
    /// <summary>
    /// Figure area
    /// </summary>
    dynamic Area { get; }
    
    /// <summary>
    /// Change notifier
    /// </summary>
    public Action? OnFigureChanged { get; set; }

    /// <summary>
    /// Change figure parameters
    /// </summary>
    /// <param name="newParams">figure new parameters</param>
    public void ChangeParameter(T newParams);
}