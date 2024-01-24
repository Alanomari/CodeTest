using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TollCalculatorTests
    {
        [TestMethod]
        public void GetTollFee_WithCarAndValidDates_ShouldReturnCorrectFee()
        {
            var car = new TollCalculator.Vehicles.Car();
            DateTime[] dates = new DateTime[]
            {
            new(2024, 1, 24, 6, 15, 0), 
            new(2024, 1, 24, 8, 45, 0), 
            new(2024, 1, 24, 15, 30, 0)
            };

            int totalTollFee = TollCalculator.TollCalculator.GetTollFee(car, dates);

            
            Assert.AreEqual(8 + 8 + 18, totalTollFee);
        }

        [TestMethod]
        public void GetTollFee_WithMotorbikeAndValidDates_ShouldReturnCorrectFee()
        {
            var motorbike = new TollCalculator.Vehicles.Motorbike();
            DateTime[] dates = new DateTime[]
            {
                new(2024, 1, 24, 6, 15, 0),
                new(2024, 1, 24, 8, 45, 0),
                new(2024, 1, 24, 15, 30, 0)
            };

            int totalTollFee = TollCalculator.TollCalculator.GetTollFee(motorbike, dates);

            
            Assert.AreEqual(8 + 8 + 18, totalTollFee);
        }


    }
}