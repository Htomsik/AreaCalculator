namespace SimpleAreaCalculatorTests;

[TestClass]
public class CircleTests
{
    /// <summary>
    ///     Negative circle radius test
    /// </summary>
    [TestMethod]
    public void CircleRadiusLessThanZeroTest()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Circle(-1d));
    }

    /// <summary>
    ///     Circle area calculation (double type)
    /// </summary>
    [TestMethod]
    public void CircleAreaCalculationTest()
    {
        //Arrange
        var circle = new Circle(10d);

        var doubleArea = 314.1592653589793d;

        //Act
        var circleArea = circle.Area;

        //Assert
        Assert.AreEqual(doubleArea, circleArea);
    }
}