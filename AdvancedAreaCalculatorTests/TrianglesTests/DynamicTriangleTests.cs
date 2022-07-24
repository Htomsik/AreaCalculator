namespace AreaCalculatorTests;

[TestClass]
public class DynamicTriangleTest
{
    /// <summary>
    ///     Triangle negative sides test
    /// </summary>
    [TestMethod]
    public void DynamicTriangleSidesLessTnanZeroTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentNullException>(() => new DynamicTriangle(-1, 0, 0d));
        Assert.ThrowsException<ArgumentNullException>(() => new DynamicTriangle(0, -1, 0d));
        Assert.ThrowsException<ArgumentNullException>(() => new DynamicTriangle(0, 0, -1d));
    }
    
    /// <summary>
    ///     Triangle with these sides doesn't exist test
    /// </summary>
    [TestMethod]
    public void DynamicTriangleIncorrectSidesTest()
    {
        //Arrange+Act+Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new DynamicTriangle(100, 0, 0d));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new DynamicTriangle(100, 0, 0m));
    }
    
    /// <summary>
    ///     Triangle area calculation test (double type)
    /// </summary>
    [TestMethod]
    public void DynamicTriangleDoubleAreaCalculationTest()
    {
        //Arrange
        var triangle = new DynamicTriangle(6, 5, 4d);

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
    public void DynamicTriangleDecimalAreaCalculationTest()
    {
        //Arrange
        var triangle = new DynamicTriangle(6, 5, 4m);

        var requiredArea = 9.921567416492214714381059076m;

        //Act
        var triangleArea = triangle.Area;

        //Assert
        Assert.AreEqual(requiredArea, triangleArea);
    }

    /// <summary>
    ///     Triangle incorrect new sides type test
    /// </summary>
    [TestMethod]
    public void DynamicTriangleIncorrectNewSidesTypeTest()
    {
        //Arrange
        var doubleTriangle = new DynamicTriangle(10, 10, 10d);

        var decimalTriangle = new DynamicTriangle(10, 10, 10m);

        //Act+Assert

        Assert.ThrowsException<ArgumentException>(() => doubleTriangle.ChangeParameter((10m, 10d, 10d)));
        Assert.ThrowsException<ArgumentException>(() => doubleTriangle.ChangeParameter((10d, 10m, 10d)));
        Assert.ThrowsException<ArgumentException>(() => doubleTriangle.ChangeParameter((10m, 10d, 10d)));

        Assert.ThrowsException<ArgumentException>(() => decimalTriangle.ChangeParameter((10d, 10m, 10m)));
        Assert.ThrowsException<ArgumentException>(() => decimalTriangle.ChangeParameter((10m, 10d, 10m)));
        Assert.ThrowsException<ArgumentException>(() => decimalTriangle.ChangeParameter((10m, 10m, 10d)));
    }


    /// <summary>
    ///     Triangle change sides test
    /// </summary>
    [TestMethod]
    public void DynamicTriangleChangeSidesTest()
    {
        //Arrange
        var doubleTriangle = new DynamicTriangle(10, 10, 10d);

        var requiredTriangle = new DynamicTriangle(20, 20, 20d);

        //Act
        doubleTriangle.ChangeParameter((20d, 20d, 20d));

        //Asserts
        Assert.AreEqual(doubleTriangle.Area, requiredTriangle.Area);
    }

    /// <summary>
    ///     Action triangle change sides test
    /// </summary>
    [TestMethod]
    public void DynamicTriangleOnFigureChangeTest()
    {
        //Arrange
        var doubleTriangle = new DynamicTriangle(10, 10, 10d);

        var requiredTriangle = new DynamicTriangle(20, 20, 20d);

        var changedArea = 0d;

        //Act
        doubleTriangle.OnFigureChanged += FigureChange;

        doubleTriangle.ChangeParameter((20d, 20d, 20d));

        void FigureChange()
        {
            changedArea = doubleTriangle.Area;
        }

        //Assert
        Assert.AreEqual(changedArea, requiredTriangle.Area);
    }


    /// <summary>
    ///     Triangle new sides negative  test
    /// </summary>
    [TestMethod]
    public void DynamicTriangleNewSidesLessTnanZeroTest()
    {
        //Arrange 
        var doubleTriangle = new DynamicTriangle(10, 10, 10d);

        //Act+Assert
        Assert.ThrowsException<ArgumentNullException>(() => doubleTriangle.ChangeParameter((-1d, 0d, 0d)));
        Assert.ThrowsException<ArgumentNullException>(() => doubleTriangle.ChangeParameter((0d, -1d, 0d)));
        Assert.ThrowsException<ArgumentNullException>(() => doubleTriangle.ChangeParameter((0d, 0d, -1d)));
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
            var triangle = new DynamicTriangle(3, 3, 3d);

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
            var triangle = new DynamicTriangle(10, 10, 14d);

            var requiredAngleType = TriangleAngleType.Acute;

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
            var triangle = new DynamicTriangle(3, 3, 5d);

            var requiredAngleType = TriangleAngleType.Obtuse;

            //Act
            var triangleAngleType = triangle.AngleType;

            //Assert
            Assert.AreEqual(requiredAngleType, triangleAngleType);
        }
    }
}