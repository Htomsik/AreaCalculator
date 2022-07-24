namespace AreaCalculatorTests;

[TestClass]
public class DynamicCircleTests
{
    /// <summary>
    ///     Negative circle radius test
    /// </summary>
    [TestMethod]
    public void DynamicCircleRadiusLessThanZeroTest()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new DynamicCircle(-1d));
    }

    /// <summary>
    ///     Circle area calculation (decimal type)
    /// </summary>
    [TestMethod]
    public void DynamicCircleDecimalAreaCalculationTest()
    {
        //Arrange
        var circle = new DynamicCircle(10m);

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
    public void DynamicCircleDoubleAreaCalculationTest()
    {
        //Arrange
        var circle = new DynamicCircle(10d);

        var doubleArea = 314.1592653589793d;

        //Act
        double circleArea = circle.Area;

        //Assert
        Assert.AreEqual(doubleArea, circleArea);
    }

    /// <summary>
    ///     Circle incorrect new radius type test
    /// </summary>
    [TestMethod]
    public void DynamicCircleIncorrectNewRadiusTypeTest()
    {
        //Arrange
        var doubleCircle = new DynamicCircle(10d);

        var decimalCircle = new DynamicCircle(10m);


        //Act+Assert
        Assert.ThrowsException<ArgumentException>(() => doubleCircle.ChangeParameter(20m));
        Assert.ThrowsException<ArgumentException>(() => decimalCircle.ChangeParameter(20d));
    }

    /// <summary>
    ///     Circle change radius test
    /// </summary>
    [TestMethod]
    public void DynamicCircleChangeRadiusTest()
    {
        //Arrange
        var doubleCircle = new DynamicCircle(10d);

        var requiredCircleArea = new DynamicCircle(20d).Area;

        //Act
        doubleCircle.ChangeParameter(20d);

        //Assert
        Assert.AreEqual(doubleCircle.Area, requiredCircleArea);
    }


    /// <summary>
    ///     Action circle change radius test
    /// </summary>
    [TestMethod]
    public void DynamicCircleOnFigureChangeTest()
    {
        //Arrange
        var doubleCircle = new DynamicCircle(10d);

        var requiredCircleArea = new DynamicCircle(20d);

        var changedArea = 0d;

        //Act
        doubleCircle.OnFigureChanged += FigureChange;

        doubleCircle.ChangeParameter(20d);

        void FigureChange()
        {
            changedArea = doubleCircle.Area;
        }

        //Assert
        Assert.AreEqual(changedArea, requiredCircleArea.Area);
    }
}