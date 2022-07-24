namespace AreaCalculator.Models.Base;

public interface IDynamicFigure<T>
{
    
    /// <summary>
    /// Figure area
    /// </summary>
    dynamic Area { get; }
    
    /// <summary>
    /// Change Notifier
    /// </summary>
    public Action? OnFigureChanged { get; set; }

    /// <summary>
    /// Change figure parameters
    /// </summary>
    /// <param name="newParams">figure parameter</param>
    public  void ChangeParameter(T newParams);
}