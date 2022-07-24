using AreaCalculator.Models.Base;

namespace AreaCalculator.Models.Dynamic;

public sealed class DynamicCircle:BaseDynamicFigure<dynamic>
{
    #region Fields
    
    private const decimal DecimalPi = 3.1415926535897932384626433832m;
    
    #endregion

    #region Properties

    /// <summary>
    /// Circle radius
    /// </summary>
    public dynamic Radius { get; private set; }

    #endregion
    
    #region Constructors

    /// <summary>
    /// Circle double
    /// </summary>
    /// <param name="radius">Circle double radius</param>
    public DynamicCircle(double radius)
    {
        Radius = radius;
        CheckException();
    }
    
    /// <summary>
    /// Circle decimal
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
        return Radius is decimal ? DecimalPi * Radius * Radius : Math.PI* Radius * Radius;
    }

    /// <summary>
    /// Check circle exception
    /// </summary>
    /// <exception cref="ArgumentException">If Radius less than 0</exception>
    protected override void CheckException()
    {
        
        if (Radius! < 0) throw new ArgumentException("Radius can't be less than 0");
        
    }

    #endregion


    /// <summary>
    /// Change Figure radius (double|decimal types)
    /// </summary>
    /// <param name="newRadius"></param>
    /// <exception cref="ArgumentException">If parameter type doesn't match the required type</exception>
    public override void ChangeParameter(dynamic newRadius)
    {
        if (Radius.GetType() != newRadius.GetType()) throw new ArgumentException("The parameter type doesn't match the required type");
        
        CheckException();
        
        Radius = newRadius;

        AreaChanged();
    }
    
    
}