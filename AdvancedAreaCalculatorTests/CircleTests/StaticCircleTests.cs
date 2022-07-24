namespace AreaCalculatorTests;

[TestClass]
public class StaticCircleTests
{
    /// <summary>
    ///     Negative circle radius test
    /// </summary>
    [TestMethod]
    public void StaticCircleRadiusLessThanZeroTest()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new StaticCircle(-1d));
    }

    /// <summary>
    ///     Circle area calculation (decimal type)
    /// </summary>
    [TestMethod]
    public void StaticCircleDecimalAreaCalculationTest()
    {
        //Arrange
        var circle = new StaticCircle(10m);

        var decimalArea = 314.15926535897932384626433832M;

        //Act
        decimal circleArea = circle.Area;

        //Assert
        Assert.AreEqual(decimalArea, circleArea);
    }

    /// <summary>
    ///     Circle area calculation (double type)
    /// </summary>
    [TestMethod]
    public void StaticCircleDoubleAreaCalculationTest()
    {
        //Arrange
        var circle = new StaticCircle(10d);

        var doubleArea = 314.1592653589793d;

        //Act
        double circleArea = circle.Area;

        //Assert
        Assert.AreEqual(doubleArea, circleArea);
    }
}