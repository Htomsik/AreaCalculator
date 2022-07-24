using AreaCalculator.Models.Base;
using AreaCalculator.Models.Dynamic;

namespace AreaCalculatorTests;

[TestClass]
public class StaticCircleTests
{
   /// <summary>
   /// Negative circle radius test 
   /// </summary>
    [TestMethod]
    public void StaticCircleRadiusLessThanZeroTest()
    {
        Assert.ThrowsException<ArgumentException>(() => new StaticCircle((double)-1));
    }
    
   /// <summary>
   /// Circle area calculation (decimal type)
   /// </summary>
    [TestMethod]
    public void StaticCircleDecimalAreaCalculationTest()
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
    public void StaticCircleDoubleAreaCalculationTest()
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

[TestClass]
public class DynamicCircleTests
{
    /// <summary>
    /// Negative circle radius test 
    /// </summary>
    [TestMethod]
    public void DynamicCircleRadiusLessThanZeroTest()
    {
        Assert.ThrowsException<ArgumentException>(() => new DynamicCircle((double)-1));
    }
    
    /// <summary>
    /// Circle area calculation (decimal type)
    /// </summary>
    [TestMethod]
    public void DynamicCircleDecimalAreaCalculationTest()
    {
        //Arrange
        var circle = new DynamicCircle((decimal)10);

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
    public void DynamicCircleDoubleAreaCalculationTest()
    {
        //Arrange
        var circle = new DynamicCircle((double)10);

        var doubleArea = 314.1592653589793d;

        //Act
        double circleArea = circle.Area;

        //Assert
        Assert.AreEqual(doubleArea, circleArea);
    }
    
    /// <summary>
    /// Circle incorrect new radius type test
    /// </summary>
    [TestMethod]
    public void DynamicCircleIncorrectRadiusTypeTest()
    {
        //Arrange
        var doubleCircle = new DynamicCircle(10d);
        
        var decimalCircle = new DynamicCircle(10m);
        
        
        //Act+Assert
        Assert.ThrowsException<ArgumentException>(() => doubleCircle.ChangeParameter(20m));
        Assert.ThrowsException<ArgumentException>(() => decimalCircle.ChangeParameter(20d));
    }
    
    /// <summary>
    /// Circle change radius test
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
        Assert.AreEqual(doubleCircle.Area,requiredCircleArea);
        
    }
    
    
    /// <summary>
    /// Action circle change radius test
    /// </summary>
    [TestMethod]
    public void DynamicCircleOnFigureChangeTest()
    {
        //Arrange
        var doubleCircle = new DynamicCircle(10d);
        
        var requiredCircleArea = new DynamicCircle(20d);

        double changedArea = 0d;
        
        //Act
        doubleCircle.OnFigureChanged += FigureChange;
        
        doubleCircle.ChangeParameter(20d);
        
        void FigureChange()
        {
            changedArea = doubleCircle.Area;
        }
        
        //Assert
        Assert.AreEqual(changedArea,requiredCircleArea.Area);
        
      
    }
    
    

    
        
   

    
}