using AreaCalculator.Models.Base;

namespace AreaCalculator.Models;

public sealed class DynamicCircle:BaseDynamicFigure<dynamic>
{
   

    #region Properties

    /// <summary>
    /// Circle radius
    /// </summary>
    public dynamic Radius { get; private set; }

    #endregion
    
    #region Constructors

    /// <summary>
    /// Dynamic Circle (double type)
    /// </summary>
    /// <param name="radius">Circle double radius</param>
    public DynamicCircle(double radius)
    {
        Radius = radius;
        CheckException();
    }
    
    /// <summary>
    /// Dynamic circle (decimal type)
    /// </summary>
    /// <param name="radius">Circle decimal radius</param>
    public DynamicCircle(decimal radius)
    {
        Radius = radius;
        CheckException();
    }

    #endregion
    
    #region Methods

    /// <summary>
    /// Calculate circle area
    /// </summary>
    protected  override dynamic CalculateArea()
    {
        return Radius is decimal ? GlobalConstants.DecimalPi * Radius * Radius : Math.PI* Radius * Radius;
    }

    /// <summary>
    /// Check circle exception
    /// </summary>
    /// <exception cref="ArgumentNullException">If Radius less than 0</exception>
    protected override void CheckException()
    {
        if (Radius! < 0) throw new ArgumentNullException("Radius can't be less than 0");
    }

    #endregion


    /// <summary>
    /// Change circle radius (double|decimal types)
    /// </summary>
    /// <param name="newRadius"></param>
    /// <exception cref="ArgumentException">If parameter type doesn't match the required type</exception>
    public override void ChangeParameter(dynamic newRadius)
    {
        if (Radius.GetType() != newRadius.GetType()) throw new ArgumentException("The parameter type doesn't match the required type");
        
        CheckException();
        
        Radius = newRadius;

        FigureChanged();
    }
    
    
}