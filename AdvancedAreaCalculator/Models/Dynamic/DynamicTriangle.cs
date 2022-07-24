using AreaCalculator.Models.Base;

namespace AreaCalculator.Models;

public sealed class DynamicTriangle:BaseDynamicFigure<(dynamic,dynamic,dynamic)>
{
    
    #region Fields

    private readonly IDecimalSqrt _decimalSqrt;
    
    #endregion
    
    #region Poperties

    public dynamic FirstSide { get; private set; }
    
    public dynamic SecondSide { get; private set; }
    
    public dynamic ThirdSide { get; private set;}

    public TriangleAngleType AngleType => AngleTypeIdentification();

    #endregion

    #region Constructors

    /// <summary>
    /// Triangle double
    /// </summary>
    /// <param name="firstSide">First side of triangle</param>
    /// <param name="secondSide">Second side of triangle</param>
    /// <param name="thirdSide">Third side of triangle</param>
    public DynamicTriangle(double firstSide, double secondSide, double thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
        
        CheckException();
        
    }
    
    /// <summary>
    /// Triangle decimal
    /// </summary>
    /// <param name="firstSide">First side of triangle</param>
    /// <param name="secondSide">Second side of triangle</param>
    /// <param name="thirdSide">Third side of triangle</param>
    public DynamicTriangle(decimal firstSide, decimal secondSide, decimal thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
        
        CheckException();

        _decimalSqrt = new BabylonianDecimalSqrt();
    }

    #endregion
    
    #region Methods

    /// <summary>
    /// Calculate triangle area
    /// </summary>
    protected override dynamic CalculateArea()
    {
        var semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

        dynamic intermediateArea = semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) *
                                 (semiPerimeter - ThirdSide);
        
        return _decimalSqrt is null ? Math.Sqrt(intermediateArea) : _decimalSqrt.Sqrt(intermediateArea)  ;
    }
    
    /// <summary>
    /// Check triangle angle type
    /// </summary>
    private TriangleAngleType AngleTypeIdentification()
    {
        var sides = new List<dynamic>() { FirstSide, SecondSide, ThirdSide };
        
        var maxSide = sides.Max();
        
        sides.Remove(maxSide);
        
        var maxSideSqr = maxSide * maxSide;
        
        var isRightAngle = maxSideSqr == sides[0]*sides[0] + sides[1]*sides[1] ;
        
        if (isRightAngle) return TriangleAngleType.Right;
        
        var isAcuteAngle = maxSideSqr < sides[0] * sides[0] + sides[1] * sides[1];
        
        if (isAcuteAngle) return TriangleAngleType.Acute;
        
        return TriangleAngleType.Obtuse;
        
    }

    /// <summary>
    /// Check triangle exception
    /// </summary>
    /// <exception cref="ArgumentNullException">If one of sides less than 0</exception>
    /// <exception cref="ArgumentOutOfRangeException">If triangle with these sides doesn't exist</exception>
    protected override void CheckException()
    {
        if (FirstSide < 0 || SecondSide < 0 || ThirdSide < 0)
            throw new ArgumentNullException("Sides of triangle can't be less than 0");
        
        if (!(FirstSide + SecondSide > ThirdSide && FirstSide + ThirdSide > SecondSide && SecondSide + ThirdSide > FirstSide))
            throw new ArgumentOutOfRangeException("A triangle with these sides doesn't exist");
        
    }
    
    /// <summary>
    /// Check triangle new sides exception
    /// </summary>
    /// <param name="newParams"> Tuple with new params Item1 = FirstSide, Item2 = SecondSide, Item3 = ThirdSide</param>
    /// <exception cref="ArgumentException">If one of sides type doesn't match the required type</exception>
    /// <exception cref="ArgumentNullException">If one of sides less than 0</exception>
    /// <exception cref="ArgumentOutOfRangeException">If triangle with these sides doesn't exist</exception>
    private void CheckException((dynamic,dynamic,dynamic) newParams)
    {
        if (newParams.Item1.GetType() != FirstSide.GetType() 
            || newParams.Item2.GetType() != SecondSide.GetType() ||
            newParams.Item3.GetType() != ThirdSide.GetType()) 
            throw new ArgumentException("One or more parameter type doesn't match the required type");
        
        if (newParams.Item1 < 0 || newParams.Item2 < 0 || newParams.Item3 < 0)
            throw new ArgumentNullException("Sides of triangle can't be less than 0");
        
        if (!(newParams.Item1 + newParams.Item2 > newParams.Item3 && newParams.Item2 + newParams.Item3 > newParams.Item1 && newParams.Item3 +  newParams.Item1 > newParams.Item2))
            throw new ArgumentOutOfRangeException("A triangle with these sides doesn't exist");
        
    }

    /// <summary>
    /// Change triangle sides
    /// </summary>
    /// <param name="newParams">Tuple with new params Item1 = FirstSide, Item2 = SecondSide, Item3 = ThirdSid</param>
    public override void ChangeParameter((dynamic,dynamic,dynamic) newParams)
    {
        CheckException(newParams);

        FirstSide = newParams.Item1;
        
        SecondSide = newParams.Item2;
        
        ThirdSide = newParams.Item3;

        FigureChanged();
    }
 

    #endregion
}