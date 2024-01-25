using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTest.Vehicles;

namespace Testing
{
    [TestClass]
    public class TollCalculatorTests
    {
        [TestMethod]
        public void GetTollFee_WithCarAndValidDates_ShouldReturnCorrectFee()
        {
            var car = new Car();
            DateTime[] dates = new DateTime[]
            {
            new(2024, 1, 24, 6, 15, 0), 
            new(2024, 1, 24, 8, 45, 0), 
            new(2024, 1, 24, 15, 30, 0)
            };

            int totalTollFee = TollCalculator.GetTollFee(car, dates);

            
            Assert.AreEqual(8 + 8 + 18, totalTollFee);
        }

        [TestMethod]
        public void GetTollFee_WithMotorbikeAndValidDates_ShouldReturnCorrectTollFreeValue()
        {
            var motorbike = new Motorbike();
            DateTime[] dates = new DateTime[]
            {
                new(2024, 1, 24, 6, 15, 0),
                new(2024, 1, 24, 8, 45, 0),
                new(2024, 1, 24, 15, 30, 0)
            };

            int totalTollFee = TollCalculator.GetTollFee(motorbike, dates);

            
            Assert.AreEqual(0, totalTollFee);
        }


    }
}