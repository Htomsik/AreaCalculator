namespace SimpleAreaCalculatorTests;

[TestClass]
public class TriangleTests
{
    /// <summary>
    ///     Triangle negative sides test
    /// </summary>
    [TestMethod]
    public void TriangleSidesLessTnanZeroTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentNullException>(() => new Triangle(-1, 0, 0));
        Assert.ThrowsException<ArgumentNullException>(() => new Triangle(0, -1, 0));
        Assert.ThrowsException<ArgumentNullException>(() => new Triangle(0, 0, -1));
    }

    /// <summary>
    ///     Triangle with these sides doesn't exist test
    /// </summary>
    [TestMethod]
    public void StaticTriangleIncorrectSidesTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(100, 0, 0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(100, 0, 0));
    }

    /// <summary>
    ///     Triangle area calculation test
    /// </summary>
    [TestMethod]
    public void TriangleAreaCalculationTest()
    {
        //Arrange
        var triangle = new Triangle(6, 5, 4d);

        var requiredArea = 9.921567416492215d;

        //Act
        var triangleArea = triangle.Area;

        //Assert
        Assert.AreEqual(requiredArea, triangleArea);
    }


    /// <summary>
    ///     Triangle right angle test
    /// </summary>
    [TestMethod]
    public void IsRightAngleTriangleTest()
    {
        //Arrange
        var triangle = new Triangle(3, 4, 5);

        //Act+Assert
        Assert.AreEqual(true, triangle.IsRightAngle);
    }
}