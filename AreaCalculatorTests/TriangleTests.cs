namespace AreaCalculatorTests;

[TestClass]
public class TriangleTests
{
    
    /// <summary>
    /// Triangle negative sides test
    /// </summary>
    [TestMethod]
    public void SidesLessTnanZeroTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentException>(() => new StaticTriangle((double)-1,0,0));
        Assert.ThrowsException<ArgumentException>(() => new StaticTriangle((double)0,-1,0));
        Assert.ThrowsException<ArgumentException>(() => new StaticTriangle((double)0,0,-1));
    }
    
    /// <summary>
    /// Triangle area calculation test (double type)
    /// </summary>
    [TestMethod]
    public void TriangleDoubleAreaCalculationTest()
    {
        //Arrange
        var triangle = new StaticTriangle(6,5,4d);
        
        var requiredArea = 9.921567416492215d;

        //Act
        var triangleArea = triangle.Area;

        //Assert
        Assert.AreEqual(requiredArea, triangleArea);
    }
    
    /// <summary>
    /// Triangle area calculation test (decimal type)
    /// </summary>
    [TestMethod]
    public void TriangleDecimalAreaCalculationTest()
    {
        //Arrange
        var triangle = new StaticTriangle(6,5,4m);
        
        var requiredArea = 9.921567416492214714381059076m;

        //Act
        var triangleArea = triangle.Area;

        //Assert
        Assert.AreEqual(requiredArea, triangleArea);
    }

  
    [TestClass]
    public class TriangleAngleTypeTests
    {
        /// <summary>
        /// Triangle acute angle test
        /// </summary>
        [TestMethod]
        public void AcuteAngleTriangleTest()
        {
            //Arrange
            var triangle = new StaticTriangle(3,3,3d);
        
            var requiredAngleType = TriangleAngleType.Acute;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }
        
        /// <summary>
        /// Triangle right angle test
        /// </summary>
        [TestMethod]
        public void RightAngleTriangleTest()
        {
            //Arrange
            var triangle = new StaticTriangle(10,10,14d);
        
            var requiredAngleType = TriangleAngleType.Acute;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }
        
        /// <summary>
        /// Triangle obtuse angle test
        /// </summary>
        [TestMethod]
        public void ObtuseAngleTriangleTest()
        {
            //Arrange
            var triangle = new StaticTriangle(3,3,5d);
        
            var requiredAngleType = TriangleAngleType.Obtuse;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }
    }
    
}