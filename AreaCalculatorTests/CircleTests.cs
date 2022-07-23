namespace AreaCalculatorTests;

[TestClass]
public class CircleTests
{
   /// <summary>
   /// Negative circle radius test 
   /// </summary>
    [TestMethod]
    public void CircleRadiusLessThanZeroTest()
    {
        Assert.ThrowsException<ArgumentException>(() => new StaticCircle((double)-1));
    }
    
   /// <summary>
   /// Circle area calculation (decimal type)
   /// </summary>
    [TestMethod]
    public void CircleDecimalAreaCalculationTest()
    {
        //Arrange
        var circle = new StaticCircle((decimal)10);

        var decimalArea = 314.15926535897932384626433832M;

        //Act
        decimal circleArea = circle.Area;

        //Assert
        Assert.AreEqual(decimalArea, circleArea);
    }
    
   /// <summary>
   /// Circle area calculation (double type)
   /// </summary>
    [TestMethod]
    public void CircleDoubleAreaCalculationTest()
    {
        //Arrange
        var circle = new StaticCircle((double)10);

        var doubleArea = 314.1592653589793d;

        //Act
        double circleArea = circle.Area;

        //Assert
        Assert.AreEqual(doubleArea, circleArea);
    }
}