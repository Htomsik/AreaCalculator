namespace SimpleAreaCalculator.Models;

public sealed class Triangle : BaseFigure
{
    #region Fields

    private readonly Lazy<bool> _isRightAngle;

    #endregion

    #region Constructors

    /// <summary>
    ///     Triangle double
    /// </summary>
    /// <param name="firstSide">First side of triangle</param>
    /// <param name="secondSide">Second side of triangle</param>
    /// <param name="thirdSide">Third side of triangle</param>
    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;

        CheckException();

        _isRightAngle = new Lazy<bool>(IsRightAngleIdentification);
    }

    #endregion

    #region Poperties

    public double FirstSide { get; }

    public double SecondSide { get; }

    public double ThirdSide { get; }

    public bool IsRightAngle => _isRightAngle.Value;

    #endregion

    #region Methods

    /// <summary>
    ///     Calculate triangle area
    /// </summary>
    protected override double CalculateArea()
    {
        var semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

        var intermediateArea = semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) *
                               (semiPerimeter - ThirdSide);

        return Math.Sqrt(intermediateArea);
    }


    /// <summary>
    ///     Check is right angle triangle
    /// </summary>
    private bool IsRightAngleIdentification()
    {
        var sides = new List<double> { FirstSide, SecondSide, ThirdSide };

        var maxSide = sides.Max();

        sides.Remove(maxSide);

        return maxSide * maxSide == sides[0] * sides[0] + sides[1] * sides[1];
    }


    /// <summary>
    ///     Check triangle exception
    /// </summary>
    /// <exception cref="ArgumentNullException">If one of sides less than 0</exception>
    /// <exception cref="ArgumentOutOfRangeException">If triangle with these sides doesn't exist</exception>
    protected override void CheckException()
    {
        if (FirstSide < 0 || SecondSide < 0 || ThirdSide < 0)
            throw new ArgumentNullException("Sides of triangle can't be less than 0");

        if (!(FirstSide + SecondSide > ThirdSide && FirstSide + ThirdSide > SecondSide &&
              SecondSide + ThirdSide > FirstSide))
            throw new ArgumentOutOfRangeException("A triangle with these sides doesn't exist");
    }

    #endregion
}