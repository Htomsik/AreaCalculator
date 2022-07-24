namespace AreaCalculatorTests;

[TestClass]
public class StaticTriangleTests
{
    /// <summary>
    ///     Triangle negative sides test
    /// </summary>
    [TestMethod]
    public void StaticTriangleSidesLessTnanZeroTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentNullException>(() => new StaticTriangle(-1, 0, 0d));
        Assert.ThrowsException<ArgumentNullException>(() => new StaticTriangle(0, -1, 0d));
        Assert.ThrowsException<ArgumentNullException>(() => new StaticTriangle(0, 0, -1d));
    }
    
    /// <summary>
    ///     Triangle with these sides doesn't exist test
    /// </summary>
    [TestMethod]
    public void StaticTriangleIncorrectSidesTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StaticTriangle(100, 0, 0d));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new StaticTriangle(100, 0, 0m));
    }

    /// <summary>
    ///     Triangle area calculation test (double type)
    /// </summary>
    [TestMethod]
    public void StaticTriangleDoubleAreaCalculationTest()
    {
        //Arrange
        var triangle = new StaticTriangle(6, 5, 4d);

        var requiredArea = 9.921567416492215d;

        //Act
        var triangleArea = triangle.Area;

        //Assert
        Assert.AreEqual(requiredArea, triangleArea);
    }

    /// <summary>
    ///     Triangle area calculation test (decimal type)
    /// </summary>
    [TestMethod]
    public void StaticTriangleDecimalAreaCalculationTest()
    {
        //Arrange
        var triangle = new StaticTriangle(6, 5, 4m);

        var requiredArea = 9.921567416492214714381059076m;

        //Act
        var triangleArea = triangle.Area;

        //Assert
        Assert.AreEqual(requiredArea, triangleArea);
    }


    [TestClass]
    public class StaticTriangleAngleTypeTests
    {
        /// <summary>
        ///     Triangle acute angle test
        /// </summary>
        [TestMethod]
        public void IsAcuteAngleTriangleTest()
        {
            //Arrange
            var triangle = new StaticTriangle(3, 3, 3d);

            var requiredAngleType = TriangleAngleType.Acute;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }

        /// <summary>
        ///     Triangle right angle test
        /// </summary>
        [TestMethod]
        public void IsRightAngleTriangleTest()
        {
            //Arrange
            var triangle = new StaticTriangle(3, 4, 5d);

            var requiredAngleType = TriangleAngleType.Right;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }

        /// <summary>
        ///     Triangle obtuse angle test
        /// </summary>
        [TestMethod]
        public void IsObtuseAngleTriangleTest()
        {
            //Arrange
            var triangle = new StaticTriangle(3, 3, 5d);

            var requiredAngleType = TriangleAngleType.Obtuse;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }
    }
}