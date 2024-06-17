using LaptopDiscount;

namespace LaptopDiscountTests
{
    [TestFixture]
    public class LaptopDiscountTests
    {
        private EmployeeDiscount _employeeDiscount;

        [SetUp]
        public void Setup()
        {
            _employeeDiscount = new EmployeeDiscount();
        }

        [Test]
        public void CalculateDiscountedPrice_NoDiscount() // To check discount for part-time employee
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartTime;
            _employeeDiscount.Price = 1000m;

            // Act
            var result = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(1000m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_5PercentDiscount() // To check discount for part-load employee
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.PartialLoad;
            _employeeDiscount.Price = 1000m;

            // Act
            var result = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(950m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_10PercentDiscount() // To check discount for full-time employee
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.FullTime;
            _employeeDiscount.Price = 1000m;

            // Act
            var result = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(900m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_20PercentDiscount()  // To check discount for CompanyPurchasing
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.CompanyPurchasing;
            _employeeDiscount.Price = 1000m;

            // Act
            var result = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(800m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_ZeroPrice_NoDiscount() // To check discount for 0 price
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.FullTime;
            _employeeDiscount.Price = 0m;

            // Act
            var result = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(0m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_NegativePrice_NoDiscount() // To check discount for negative price price
        {
            // Arrange
            _employeeDiscount.EmployeeType = EmployeeType.CompanyPurchasing;
            _employeeDiscount.Price = -1000m;

            // Act
            var result = _employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(-800m, result);
        }
    }
}
